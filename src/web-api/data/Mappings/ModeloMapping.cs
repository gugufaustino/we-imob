using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ModeloMapping : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.DtNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.Rg)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Diponibilidade)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasColumnType("varchar(15)");


            builder.Property(p => p.Instagram)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Facebook)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Linkedin)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Altura)
                .IsRequired();
            builder.Property(p => p.Peso)
                .IsRequired();
            builder.Property(p => p.Manequim)
                .IsRequired();
            builder.Property(p => p.Sapato)
                .IsRequired();

            builder.Property(p => p.CorOlhos)
                .IsRequired();
            builder.Property(p => p.CorCabelo)
                .IsRequired();
            builder.Property(p => p.TipoCabelo)
                .IsRequired();
            builder.Property(p => p.TipoCabeloComprimento)
                .IsRequired();

            builder.Property(p => p.DthInclusao)
                .IsRequired();
            builder.Property(p => p.DthAtualizacao)
                .IsRequired();

            builder.Property(p => p.UsuarioInclusao)
                .IsRequired()
                .HasColumnType("varchar(250)"); 

            builder.Property(p => p.UsuarioAtualizacao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.ImagemPerfilNome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

       



            builder.ToTable("Modelos");

            // 1 : N =>
            builder.HasMany(f => f.ModeloTipoCasting)
               .WithOne(p => p.Modelo)
               .HasForeignKey(prop => prop.IdModelo);

            builder.Property(t => t.IdEndereco).IsRequired();
            builder.HasOne(e => e.Endereco)
                    .WithMany()
                    .HasForeignKey(i => i.IdEndereco);

            builder.Property(t => t.IdTipoSituacao).IsRequired();
            builder.HasOne(e => e.TipoSituacao)
                    .WithMany()
                    .HasForeignKey(i => i.IdTipoSituacao);

            builder.Property(p => p.IdAgencia).IsRequired();
            builder.HasIndex(i => new { i.CPF, i.IdAgencia }).IsUnique();
            builder.HasOne(e => e.Agencia)
                    .WithMany()
                    .HasForeignKey(i => i.IdAgencia);
        }
    }
}
