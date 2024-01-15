﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(LabManagerDBContext))]
    partial class LabManagerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("API.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MeasurementType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("API.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProtocolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProtocolId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("API.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ForSale")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ForSaleQt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genus")
                        .HasColumnType("TEXT");

                    b.Property<bool>("InTS")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InTSQt")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MotherPlantsQt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TotalQt")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("API.Models.Protocol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resource")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Protocols");
                });

            modelBuilder.Entity("IngredientMedia", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListOfMediasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredientsId", "ListOfMediasId");

                    b.HasIndex("ListOfMediasId");

                    b.ToTable("IngredientMedia");
                });

            modelBuilder.Entity("API.Models.Media", b =>
                {
                    b.HasOne("API.Models.Protocol", "Protocol")
                        .WithMany("Media")
                        .HasForeignKey("ProtocolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Protocol");
                });

            modelBuilder.Entity("API.Models.Protocol", b =>
                {
                    b.HasOne("API.Models.Plant", "Plant")
                        .WithMany("Protocols")
                        .HasForeignKey("PlantId");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("IngredientMedia", b =>
                {
                    b.HasOne("API.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Media", null)
                        .WithMany()
                        .HasForeignKey("ListOfMediasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Plant", b =>
                {
                    b.Navigation("Protocols");
                });

            modelBuilder.Entity("API.Models.Protocol", b =>
                {
                    b.Navigation("Media");
                });
#pragma warning restore 612, 618
        }
    }
}
