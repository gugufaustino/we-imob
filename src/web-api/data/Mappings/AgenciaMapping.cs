using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class OrganizacaoMapping : IEntityTypeConfiguration<Organizacao>
    {

        public void Configure(EntityTypeBuilder<Organizacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            
            builder.Property(p => p.Instagram)                    
                    .HasColumnType("varchar(250)");

            builder.Property(p => p.TipoCadastro)
                    .IsRequired();

            builder.ToTable("Agencias");

            // 1 : N =>
            builder.HasMany(f => f.Usuario)
               .WithOne(p => p.Agencia)
               .HasForeignKey(prop => prop.IdAgencia);


            builder.HasOne(f => f.Empresa)
                    .WithOne()
                    .HasForeignKey<Empresa>(pr => pr.Id);

        }

    } 
}
