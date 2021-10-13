﻿// <auto-generated />
using System;
using Clientes.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clientes.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211013124809_FluentAPI")]
    partial class FluentAPI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clientes.Domain.Models.Bairro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Bairros");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BairroId")
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("BairroId");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId")
                        .IsUnique()
                        .HasFilter("[ClienteId] IS NOT NULL");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoAparelhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Clientes.Domain.Models.TipoAparelho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposAparelhos");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Endereco", b =>
                {
                    b.HasOne("Clientes.Domain.Models.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId");

                    b.HasOne("Clientes.Domain.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("Clientes.Domain.Models.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("Clientes.Domain.Models.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Bairro");

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Telefone", b =>
                {
                    b.HasOne("Clientes.Domain.Models.Cliente", "Cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Clientes.Domain.Models.Cliente", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
