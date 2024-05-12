﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("API.Models.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Vip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("tabClientes");
                });

            modelBuilder.Entity("API.Models.Eventos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("EstiloMusical")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Organizacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tabEventos");
                });

            modelBuilder.Entity("API.Models.Funcionario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventosId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Funcao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventosId");

                    b.ToTable("tabFuncionarios");
                });

            modelBuilder.Entity("API.Models.Funcionario", b =>
                {
                    b.HasOne("API.Models.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventosId");

                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
