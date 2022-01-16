﻿// <auto-generated />
using System;
using Mateut_Andreea_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mateut_Andreea_Proiect.Migrations
{
    [DbContext(typeof(Mateut_Andreea_ProiectContext))]
    [Migration("20220116121524_MouvieCategory")]
    partial class MouvieCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Mouvie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PriceTicket")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Regizor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReleaserID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ReleaserID");

                    b.ToTable("Mouvie");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.MouvieCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("MouvieID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("MouvieID");

                    b.ToTable("MouvieCategory");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Releaser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReleaserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Releaser");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Mouvie", b =>
                {
                    b.HasOne("Mateut_Andreea_Proiect.Models.Releaser", "Releaser")
                        .WithMany("Mouvies")
                        .HasForeignKey("ReleaserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Releaser");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.MouvieCategory", b =>
                {
                    b.HasOne("Mateut_Andreea_Proiect.Models.Category", "Category")
                        .WithMany("MouvieCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mateut_Andreea_Proiect.Models.Mouvie", "Mouvie")
                        .WithMany("MouvieCategories")
                        .HasForeignKey("MouvieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Mouvie");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Category", b =>
                {
                    b.Navigation("MouvieCategories");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Mouvie", b =>
                {
                    b.Navigation("MouvieCategories");
                });

            modelBuilder.Entity("Mateut_Andreea_Proiect.Models.Releaser", b =>
                {
                    b.Navigation("Mouvies");
                });
#pragma warning restore 612, 618
        }
    }
}