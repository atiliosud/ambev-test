﻿// <auto-generated />
using System;
using AmbevTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmbevTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("AmbevTest.Domain.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Principal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RevendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("AmbevTest.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RevendaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AmbevTest.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Produto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("AmbevTest.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("TEXT");

                    b.Property<int>("RevendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("AmbevTest.Domain.Entities.Revenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Revendas");
                });

            modelBuilder.Entity("AmbevTest.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RevendaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
