using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(t => t.Cep).HasMaxLength(9);
            builder.Property(t => t.Logradouro).HasMaxLength(250);
            builder.Property(t => t.Numero);
            builder.Property(t => t.Complemento).HasMaxLength(80);
            builder.Property(t => t.Bairro).HasMaxLength(80);
            builder.Property(t => t.NomeMunicipio).IsRequired().HasMaxLength(80);
            builder.Property(t => t.SiglaUf).IsRequired().HasMaxLength(2);
            builder.Property(t => t.Latitude);
            builder.Property(t => t.Longitude);


            //builder.ToTable("Enderecos");

             

        }
    }
}
