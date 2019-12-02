﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PregledEvidencija.Data;

namespace PregledEvidencija.Migrations
{
    [DbContext(typeof(PEContext))]
    [Migration("20191201200318_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PregledEvidencija.Models.InspekcijskaKontrola", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKontrole")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KontrolisaniProizvodID")
                        .HasColumnType("int");

                    b.Property<int?>("NadleznoTijeloID")
                        .HasColumnType("int");

                    b.Property<bool>("ProizvodSiguran")
                        .HasColumnType("bit");

                    b.Property<string>("RezultatiKontrole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KontrolisaniProizvodID");

                    b.HasIndex("NadleznoTijeloID");

                    b.ToTable("InspekcijskaKontrolas");
                });

            modelBuilder.Entity("PregledEvidencija.Models.InspekcijskoTijelo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Inspektorat")
                        .HasColumnType("int");

                    b.Property<string>("KontaktOsoba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nadleznost")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("InspekcijskoTijelos");
                });

            modelBuilder.Entity("PregledEvidencija.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proizvodjac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerijskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZemljaPorijekla")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Proizvods");
                });

            modelBuilder.Entity("PregledEvidencija.Models.InspekcijskaKontrola", b =>
                {
                    b.HasOne("PregledEvidencija.Models.Proizvod", "KontrolisaniProizvod")
                        .WithMany()
                        .HasForeignKey("KontrolisaniProizvodID");

                    b.HasOne("PregledEvidencija.Models.InspekcijskoTijelo", "NadleznoTijelo")
                        .WithMany()
                        .HasForeignKey("NadleznoTijeloID");
                });
#pragma warning restore 612, 618
        }
    }
}
