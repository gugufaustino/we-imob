using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoSituacao> TipoSituacao { get; set; }        
        public DbSet<Organizacao> Organizacao { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aplica padrão para entidades nao mapeadas
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()))
            {
                if (property.ClrType == typeof(string))
                    property.SetColumnType("varchar(1)");

                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    property.SetColumnType("decimal(18,2)");
            }

            // mappeia todas classes mappings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //apos mapeamento, substitui as mapeadas nvarchar para varchar
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(string))
                    property.SetIsUnicode(false);

            }

            //Impedindo exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }


            //#region Seed
             modelBuilder.Entity<TipoSituacao>().HasData(new TipoSituacao(TipoSituacaoEnum.EmElaboracao,  TipoSituacaoEnum.EmElaboracao.ToString()));
             modelBuilder.Entity<TipoSituacao>().HasData(new TipoSituacao (TipoSituacaoEnum.Ativado, TipoSituacaoEnum.Ativado.ToString()));
             modelBuilder.Entity<TipoSituacao>().HasData(new TipoSituacao (TipoSituacaoEnum.Desativado, TipoSituacaoEnum.Desativado.ToString()));

            //#endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
