﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UeLib.Data;

#nullable disable

namespace UeLib.Migrations
{
    [DbContext(typeof(UeLibContext))]
    [Migration("20220430073718_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("UeLib.Data.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("MaxVersion")
                        .HasColumnType("REAL");

                    b.Property<float>("MinVersion")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("UeLib.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("UeLib.Data.Models.RankedAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Rank")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("ProjectId");

                    b.ToTable("RankedAssets");
                });

            modelBuilder.Entity("UeLib.Data.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("UeLib.Data.Models.RankedAsset", b =>
                {
                    b.HasOne("UeLib.Data.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UeLib.Data.Models.Project", "Project")
                        .WithMany("Assets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("UeLib.Data.Models.Tag", b =>
                {
                    b.HasOne("UeLib.Data.Models.Asset", null)
                        .WithMany("Tags")
                        .HasForeignKey("AssetId");
                });

            modelBuilder.Entity("UeLib.Data.Models.Asset", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("UeLib.Data.Models.Project", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
