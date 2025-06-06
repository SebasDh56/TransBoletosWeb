﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransporteBoletos.Data;

#nullable disable

namespace TransporteBoletos.Migrations
{
    [DbContext(typeof(TransporteBoletosDbContext))]
    [Migration("20250509042020_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransporteBoletos.Models.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroBoleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.Property<int>("RutaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PasajeroId");

                    b.HasIndex("RutaId");

                    b.ToTable("Boletos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaCompra = new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            NumeroBoleto = "B001",
                            PasajeroId = 1,
                            RutaId = 1
                        });
                });

            modelBuilder.Entity("TransporteBoletos.Models.Pasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RutaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RutaId");

                    b.ToTable("Pasajeros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Documento = "12345678",
                            Nombre = "Juan Pérez",
                            RutaId = 1
                        });
                });

            modelBuilder.Entity("TransporteBoletos.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rutas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Destino = "Ciudad B",
                            Origen = "Ciudad A"
                        },
                        new
                        {
                            Id = 2,
                            Destino = "Ciudad C",
                            Origen = "Ciudad B"
                        });
                });

            modelBuilder.Entity("TransporteBoletos.Models.Boleto", b =>
                {
                    b.HasOne("TransporteBoletos.Models.Pasajero", "Pasajero")
                        .WithMany("Boletos")
                        .HasForeignKey("PasajeroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TransporteBoletos.Models.Ruta", "Ruta")
                        .WithMany("Boletos")
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pasajero");

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("TransporteBoletos.Models.Pasajero", b =>
                {
                    b.HasOne("TransporteBoletos.Models.Ruta", "Ruta")
                        .WithMany("Pasajeros")
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("TransporteBoletos.Models.Pasajero", b =>
                {
                    b.Navigation("Boletos");
                });

            modelBuilder.Entity("TransporteBoletos.Models.Ruta", b =>
                {
                    b.Navigation("Boletos");

                    b.Navigation("Pasajeros");
                });
#pragma warning restore 612, 618
        }
    }
}
