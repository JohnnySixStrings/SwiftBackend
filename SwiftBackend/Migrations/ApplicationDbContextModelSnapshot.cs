﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftBackend.Data;

#nullable disable

namespace SwiftBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("SwiftBackend.Data.Camera", b =>
                {
                    b.Property<int>("CameraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MacroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ZoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CameraId");

                    b.HasIndex("MacroId");

                    b.HasIndex("ZoomId");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("SwiftBackend.Data.Filter", b =>
                {
                    b.Property<int>("FilterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CameraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kelvin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tint")
                        .HasColumnType("INTEGER");

                    b.HasKey("FilterId");

                    b.HasIndex("CameraId");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("SwiftBackend.Data.Lense", b =>
                {
                    b.Property<int>("LenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CameraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kelvin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tint")
                        .HasColumnType("INTEGER");

                    b.HasKey("LenseId");

                    b.HasIndex("CameraId");

                    b.ToTable("Lenses");
                });

            modelBuilder.Entity("SwiftBackend.Data.Macro", b =>
                {
                    b.Property<int>("MacroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kelvin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tint")
                        .HasColumnType("INTEGER");

                    b.HasKey("MacroId");

                    b.ToTable("Macro");
                });

            modelBuilder.Entity("SwiftBackend.Data.Zoom", b =>
                {
                    b.Property<int>("ZoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kelvin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tint")
                        .HasColumnType("INTEGER");

                    b.HasKey("ZoomId");

                    b.ToTable("Zoom");
                });

            modelBuilder.Entity("SwiftBackend.Data.Camera", b =>
                {
                    b.HasOne("SwiftBackend.Data.Macro", "Macro")
                        .WithMany()
                        .HasForeignKey("MacroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwiftBackend.Data.Zoom", "Zoom")
                        .WithMany()
                        .HasForeignKey("ZoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Macro");

                    b.Navigation("Zoom");
                });

            modelBuilder.Entity("SwiftBackend.Data.Filter", b =>
                {
                    b.HasOne("SwiftBackend.Data.Camera", null)
                        .WithMany("Filters")
                        .HasForeignKey("CameraId");
                });

            modelBuilder.Entity("SwiftBackend.Data.Lense", b =>
                {
                    b.HasOne("SwiftBackend.Data.Camera", null)
                        .WithMany("Lenses")
                        .HasForeignKey("CameraId");
                });

            modelBuilder.Entity("SwiftBackend.Data.Camera", b =>
                {
                    b.Navigation("Filters");

                    b.Navigation("Lenses");
                });
#pragma warning restore 612, 618
        }
    }
}