﻿// <auto-generated />
using System;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231029204508_usuario_nullable")]
    partial class usuario_nullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("NomeMunicipio")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("SiglaUf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Domain.Models.Organizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoCadastro")
                        .HasColumnType("int");

                    b.Property<int>("TipoSituacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Organizacao");
                });

            modelBuilder.Entity("Domain.Models.TipoSituacao", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NomeTipoSituacao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TipoSituacao");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            NomeTipoSituacao = "EmElaboracao"
                        },
                        new
                        {
                            Id = 1,
                            NomeTipoSituacao = "Ativado"
                        },
                        new
                        {
                            Id = 2,
                            NomeTipoSituacao = "Desativado"
                        });
                });

            modelBuilder.Entity("Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("IdOrganizacao")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoCadastro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganizacao");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Empresa", b =>
                {
                    b.HasOne("Domain.Models.Organizacao", null)
                        .WithOne("Empresa")
                        .HasForeignKey("Domain.Models.Empresa", "Id")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Usuario", b =>
                {
                    b.HasOne("Domain.Models.Organizacao", "Organizacao")
                        .WithMany("Usuario")
                        .HasForeignKey("IdOrganizacao");

                    b.Navigation("Organizacao");
                });

            modelBuilder.Entity("Domain.Models.Organizacao", b =>
                {
                    b.Navigation("Empresa")
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}