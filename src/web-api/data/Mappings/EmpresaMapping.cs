using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(p => p.Id);            
            builder.Property(t => t.Id).ValueGeneratedNever();            


            builder.Property(p => p.RazaoSocial)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

            builder.HasIndex(i => i.Cnpj).IsUnique();
            builder.Property(p => p.Cnpj)
                    .IsRequired()
                    .HasColumnType("varchar(14)");


            builder.Property(p => p.NomeFantasia)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            
            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

            //builder.ToTable("AgenciasEmpresa"); 


        }

    }
}
