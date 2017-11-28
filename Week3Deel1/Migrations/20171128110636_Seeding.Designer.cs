﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Week3Deel1.Models;

namespace Week3Deel1.Migrations
{
    [DbContext(typeof(PopgroepContext))]
    [Migration("20171128110636_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week3Deel1.Models.Artiest", b =>
                {
                    b.Property<int>("ArtiestId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstrumentId");

                    b.Property<string>("Naam");

                    b.Property<int>("PopgroepId");

                    b.HasKey("ArtiestId");

                    b.HasIndex("InstrumentId");

                    b.HasIndex("PopgroepId");

                    b.ToTable("Artiesten");
                });

            modelBuilder.Entity("Week3Deel1.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instrumenten");
                });

            modelBuilder.Entity("Week3Deel1.Models.Popgroep", b =>
                {
                    b.Property<int>("PopgroepId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("PopgroepId");

                    b.ToTable("Popgroepen");
                });

            modelBuilder.Entity("Week3Deel1.Models.Artiest", b =>
                {
                    b.HasOne("Week3Deel1.Models.Instrument", "Instrument")
                        .WithMany("Artiesten")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Week3Deel1.Models.Popgroep", "Popgroep")
                        .WithMany("Artiesten")
                        .HasForeignKey("PopgroepId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
