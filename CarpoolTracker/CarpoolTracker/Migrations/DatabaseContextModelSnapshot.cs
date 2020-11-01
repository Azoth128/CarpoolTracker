﻿// <auto-generated />
using System;
using CarpoolTracker.Services.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarpoolTracker.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("CarpoolTracker.Models.Drive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("DriverId");

                    b.ToTable("Drives");
                });

            modelBuilder.Entity("CarpoolTracker.Models.DriveDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DriveDefinitions");
                });

            modelBuilder.Entity("CarpoolTracker.Models.DrivePlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DriveDefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DriveDefinitionId");

                    b.ToTable("DrivePlans");
                });

            modelBuilder.Entity("CarpoolTracker.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Argb")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("DriveDefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DriveDefinitionId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("CarpoolTracker.Models.Drive", b =>
                {
                    b.HasOne("CarpoolTracker.Models.DriveDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");

                    b.HasOne("CarpoolTracker.Models.Person", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");
                });

            modelBuilder.Entity("CarpoolTracker.Models.DrivePlan", b =>
                {
                    b.HasOne("CarpoolTracker.Models.DriveDefinition", "DriveDefinition")
                        .WithMany()
                        .HasForeignKey("DriveDefinitionId");
                });

            modelBuilder.Entity("CarpoolTracker.Models.Person", b =>
                {
                    b.HasOne("CarpoolTracker.Models.DriveDefinition", null)
                        .WithMany("People")
                        .HasForeignKey("DriveDefinitionId");
                });
#pragma warning restore 612, 618
        }
    }
}