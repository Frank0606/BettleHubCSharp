﻿// <auto-generated />
using System;
using BettleHubCsharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BettleHubCsharp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BettleHubCsharp.Models.Biologo", b =>
                {
                    b.Property<int>("Id_biologo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_biologo"));

                    b.Property<string>("Contrasena_biologo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo_biologo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Edad_biologo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_biologo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Protegida")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("Telefono_biologo")
                        .HasColumnType("bigint");

                    b.Property<string>("Usuario_biologo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_biologo");

                    b.ToTable("Biologo");

                    b.HasData(
                        new
                        {
                            Id_biologo = 1,
                            Contrasena_biologo = "1234",
                            Correo_biologo = "Correo1",
                            Edad_biologo = 19,
                            Nombre_biologo = "Nombre1",
                            Protegida = true,
                            Telefono_biologo = 9999999999L,
                            Usuario_biologo = "Usuario1"
                        },
                        new
                        {
                            Id_biologo = 2,
                            Contrasena_biologo = "1234",
                            Correo_biologo = "Correo2",
                            Edad_biologo = 20,
                            Nombre_biologo = "Nombre2",
                            Protegida = true,
                            Telefono_biologo = 9999999999L,
                            Usuario_biologo = "Usuario2"
                        },
                        new
                        {
                            Id_biologo = 3,
                            Contrasena_biologo = "1234",
                            Correo_biologo = "Correo3",
                            Edad_biologo = 18,
                            Nombre_biologo = "Nombre3",
                            Protegida = true,
                            Telefono_biologo = 9999999999L,
                            Usuario_biologo = "Usuario3"
                        },
                        new
                        {
                            Id_biologo = 4,
                            Contrasena_biologo = "1234",
                            Correo_biologo = "Correo4",
                            Edad_biologo = 23,
                            Nombre_biologo = "Nombre4",
                            Protegida = true,
                            Telefono_biologo = 9999999999L,
                            Usuario_biologo = "Usuario4"
                        });
                });

            modelBuilder.Entity("BettleHubCsharp.Models.Escarabajo", b =>
                {
                    b.Property<string>("Especie_escarabajo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Alas_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Antena_escarabajo")
                        .HasColumnType("int");

                    b.Property<string>("Audios_escarabajo")
                        .HasColumnType("longtext");

                    b.Property<string>("Ciclo_vida_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Elitros_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Familia_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagenes_escarabajo")
                        .HasColumnType("longtext");

                    b.Property<string>("Mandibula_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_comun_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ojos_escarabajos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Patas_escarabajo")
                        .HasColumnType("int");

                    b.Property<bool>("Protegida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Torax_escarabajo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Especie_escarabajo");

                    b.ToTable("Escarabajo");

                    b.HasData(
                        new
                        {
                            Especie_escarabajo = "especie1",
                            Alas_escarabajo = "alas1",
                            Antena_escarabajo = 1,
                            Audios_escarabajo = "[]",
                            Ciclo_vida_escarabajo = "ciclo_vida1",
                            Elitros_escarabajo = "elitros1",
                            Familia_escarabajo = "familia1",
                            Genero_escarabajo = "genero1",
                            Imagenes_escarabajo = "[]",
                            Mandibula_escarabajo = "mandibula1",
                            Nombre_comun_escarabajo = "nombre_comun1",
                            Ojos_escarabajos = "ojos1",
                            Patas_escarabajo = 1,
                            Protegida = true,
                            Torax_escarabajo = "torax1"
                        },
                        new
                        {
                            Especie_escarabajo = "especie2",
                            Alas_escarabajo = "alas2",
                            Antena_escarabajo = 2,
                            Audios_escarabajo = "[]",
                            Ciclo_vida_escarabajo = "ciclo_vida2",
                            Elitros_escarabajo = "elitros2",
                            Familia_escarabajo = "familia2",
                            Genero_escarabajo = "genero2",
                            Imagenes_escarabajo = "[]",
                            Mandibula_escarabajo = "mandibula2",
                            Nombre_comun_escarabajo = "nombre_comun2",
                            Ojos_escarabajos = "ojos2",
                            Patas_escarabajo = 2,
                            Protegida = true,
                            Torax_escarabajo = "torax2"
                        },
                        new
                        {
                            Especie_escarabajo = "especie3",
                            Alas_escarabajo = "alas3",
                            Antena_escarabajo = 3,
                            Audios_escarabajo = "[]",
                            Ciclo_vida_escarabajo = "ciclo_vida3",
                            Elitros_escarabajo = "elitros3",
                            Familia_escarabajo = "familia3",
                            Genero_escarabajo = "genero3",
                            Imagenes_escarabajo = "[]",
                            Mandibula_escarabajo = "mandibula3",
                            Nombre_comun_escarabajo = "nombre_comun3",
                            Ojos_escarabajos = "ojos3",
                            Patas_escarabajo = 3,
                            Protegida = true,
                            Torax_escarabajo = "torax3"
                        },
                        new
                        {
                            Especie_escarabajo = "especie4",
                            Alas_escarabajo = "alas4",
                            Antena_escarabajo = 4,
                            Audios_escarabajo = "[]",
                            Ciclo_vida_escarabajo = "ciclo_vida4",
                            Elitros_escarabajo = "elitros4",
                            Familia_escarabajo = "familia4",
                            Genero_escarabajo = "genero4",
                            Imagenes_escarabajo = "[]",
                            Mandibula_escarabajo = "mandibula4",
                            Nombre_comun_escarabajo = "nombre_comun4",
                            Ojos_escarabajos = "ojos4",
                            Patas_escarabajo = 4,
                            Protegida = true,
                            Torax_escarabajo = "torax4"
                        });
                });

            modelBuilder.Entity("BiologoEscarabajo", b =>
                {
                    b.Property<int>("BiologosId_biologo")
                        .HasColumnType("int");

                    b.Property<string>("EscarabajosEspecie_escarabajo")
                        .HasColumnType("varchar(255)");

                    b.HasKey("BiologosId_biologo", "EscarabajosEspecie_escarabajo");

                    b.HasIndex("EscarabajosEspecie_escarabajo");

                    b.ToTable("BiologoEscarabajo");
                });

            modelBuilder.Entity("BiologoEscarabajo", b =>
                {
                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("BiologosId_biologo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BettleHubCsharp.Models.Escarabajo", null)
                        .WithMany()
                        .HasForeignKey("EscarabajosEspecie_escarabajo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}