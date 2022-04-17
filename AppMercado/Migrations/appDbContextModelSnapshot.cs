﻿// <auto-generated />
using System;
using AppMercado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppMercado.Migrations
{
    [DbContext(typeof(appDbContext))]
    partial class appDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AppMercado.Models.Pedido", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("dataPedido")
                        .HasColumnType("int");

                    b.Property<int>("numeroPedido")
                        .HasColumnType("int");

                    b.Property<string>("observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("idPedido");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("AppMercado.Models.Pessoa", b =>
                {
                    b.Property<int>("idPessoa")
                        .HasColumnType("int");

                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dataCadastro")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("AppMercado.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("srcImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("AppMercado.Models.ItemPedido", b =>
                {
                    b.Property<int>("idItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("pedidoidPedido")
                        .HasColumnType("int");

                    b.Property<int?>("produtoid")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("valorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idItem");

                    b.HasIndex("pedidoidPedido");

                    b.HasIndex("produtoid");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("AppMercado.Models.Pessoa", b =>
                {
                    b.HasOne("AppMercado.Models.Pedido", "pedido")
                        .WithOne("pessoa")
                        .HasForeignKey("AppMercado.Models.Pessoa", "idPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("AppMercado.Models.ItemPedido", b =>
                {
                    b.HasOne("AppMercado.Models.Pedido", "pedido")
                        .WithMany("itens")
                        .HasForeignKey("pedidoidPedido");

                    b.HasOne("AppMercado.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoid");

                    b.Navigation("pedido");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("AppMercado.Models.Pedido", b =>
                {
                    b.Navigation("itens");

                    b.Navigation("pessoa")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}