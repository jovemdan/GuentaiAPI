﻿// <auto-generated />
using System;
using Guentai.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Guentai.API.Migrations
{
    [DbContext(typeof(GuentaiDbContext))]
    [Migration("20210603032000_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Guentai.API.Data.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Guentai.API.Data.ClienteMesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MesaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("MesaId");

                    b.ToTable("ClientesMesas");
                });

            modelBuilder.Entity("Guentai.API.Data.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HoraFim")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("PerfilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Guentai.API.Data.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdCadeiras")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("Guentai.API.Data.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasMaxLength(80)
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Perfis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "ADM"
                        });
                });

            modelBuilder.Entity("Guentai.API.Data.Cliente", b =>
                {
                    b.HasOne("Guentai.API.Data.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Guentai.API.Data.ClienteMesa", b =>
                {
                    b.HasOne("Guentai.API.Data.Cliente", "Cliente")
                        .WithMany("ClienteMesa")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Guentai.API.Data.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("Guentai.API.Data.Mesa", "Mesa")
                        .WithMany("ClienteMesa")
                        .HasForeignKey("MesaId");

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Guentai.API.Data.Funcionario", b =>
                {
                    b.HasOne("Guentai.API.Data.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Guentai.API.Data.Mesa", b =>
                {
                    b.HasOne("Guentai.API.Data.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Guentai.API.Data.Cliente", b =>
                {
                    b.Navigation("ClienteMesa");
                });

            modelBuilder.Entity("Guentai.API.Data.Mesa", b =>
                {
                    b.Navigation("ClienteMesa");
                });
#pragma warning restore 612, 618
        }
    }
}
