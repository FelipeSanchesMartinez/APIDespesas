﻿// <auto-generated />
using System;
using Despesas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace despesas.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20230508183439_AdicionarTrasacaoCorrecao")]
    partial class AdicionarTrasacaoCorrecao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Despesas.Models.Banco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Banco");
                });

            modelBuilder.Entity("Despesas.Models.TransacaoCategoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TransacaoCategoria");
                });

            modelBuilder.Entity("despesas.Models.Carteira", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BancoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<double>("Saldo")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("despesas.Models.Transacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<long>("TransacaoCategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("TransacaoCategoriaId");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("despesas.Models.Carteira", b =>
                {
                    b.HasOne("Despesas.Models.Banco", "Banco")
                        .WithMany("Carteiras")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("despesas.Models.Transacao", b =>
                {
                    b.HasOne("Despesas.Models.TransacaoCategoria", "Categoria")
                        .WithMany("Trasacoes")
                        .HasForeignKey("TransacaoCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Despesas.Models.Banco", b =>
                {
                    b.Navigation("Carteiras");
                });

            modelBuilder.Entity("Despesas.Models.TransacaoCategoria", b =>
                {
                    b.Navigation("Trasacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
