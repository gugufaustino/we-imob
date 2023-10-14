using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Password);
            builder.Ignore(p => p.ConfirmPassword);


            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Telefone)
                    .HasColumnType("varchar(15)");

            builder.Property(p => p.CPF)
                   .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Apelido)
                    .HasColumnType("varchar(50)");
            
            builder.Property(p => p.Imagem)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.TipoCadastro)
                     .IsRequired();

            builder.Property(p => p.IdAgencia);

            builder.ToTable("Usuarios");
 
            
            //Convesão: Na classe que possui as filhas que se configura o relacionamento. Exempo:
            // 1: 1 => forn-endereço
            // builder.HasOne(f=> f.Endereco)
            //         .WithOne(e=> e.Fornecedor)

            // 1 : N => forn-produtos 
            //  builder.HasMany(f=> f.produtos)
            //         .WithOne(p=> p.Fornecedor)
            //          .HasForeingKey(p=> p.FornecedorId)
        }
    }
}
