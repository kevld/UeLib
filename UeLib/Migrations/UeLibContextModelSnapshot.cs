﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UeLib.Data;

#nullable disable

namespace UeLib.Migrations
{
    [DbContext(typeof(UeLibContext))]
    partial class UeLibContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("UeLib.Data.Models.AssetTag", b =>
                {
                    b.Property<int>("AssetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AssetId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AssetTag");
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("UeLib.Data.Models.AssetTag", b =>
                {
                    b.HasOne("UeLib.Data.Models.Asset", "Asset")
                        .WithMany("AssetTags")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UeLib.Data.Models.Tag", "Tag")
                        .WithMany("AssetTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("UeLib.Data.Models.RankedAsset", b =>
                {
                    b.HasOne("UeLib.Data.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UeLib.Data.Models.Project", "Project")
                        .WithMany("RankedAssets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("UeLib.Data.Models.Asset", b =>
                {
                    b.Navigation("AssetTags");
                });

            modelBuilder.Entity("UeLib.Data.Models.Project", b =>
                {
                    b.Navigation("RankedAssets");
                });

            modelBuilder.Entity("UeLib.Data.Models.Tag", b =>
                {
                    b.Navigation("AssetTags");
                });
#pragma warning restore 612, 618
        }
    }
}
