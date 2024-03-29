﻿// <auto-generated />
using System;
using Jukebox.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jukebox.DAL.Migrations
{
    [DbContext(typeof(JukeboxDbContext))]
    [Migration("20240202045925_Songs_AddVotesAndYear")]
    partial class Songs_AddVotesAndYear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("Jukebox.DAL.Entities.Performer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Performers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "The Beatles"
                        },
                        new
                        {
                            Id = 2,
                            Name = "The Rolling Stones"
                        });
                });

            modelBuilder.Entity("Jukebox.DAL.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("PerformerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Votes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PerformerId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Strawberry Fields",
                            PerformerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yellow Submarine",
                            PerformerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "The Long and Winding Road",
                            PerformerId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "All You Need Is Love",
                            PerformerId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tumblin Dice",
                            PerformerId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Gimme Shelter",
                            PerformerId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Angie",
                            PerformerId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Wild Horses",
                            PerformerId = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Can't You Hear Me Knocking",
                            PerformerId = 2
                        });
                });

            modelBuilder.Entity("Jukebox.DAL.Entities.Song", b =>
                {
                    b.HasOne("Jukebox.DAL.Entities.Performer", "Performer")
                        .WithMany("Songs")
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("Jukebox.DAL.Entities.Performer", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
