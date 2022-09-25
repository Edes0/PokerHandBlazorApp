﻿// <auto-generated />
using System;
using DataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20220922121645_addCardsTableAndRelationship")]
    partial class addCardsTableAndRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("HandId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Entities.Hand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StringOfCards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("Entities.Card", b =>
                {
                    b.HasOne("Entities.Card", null)
                        .WithMany("hand")
                        .HasForeignKey("CardId");

                    b.HasOne("Entities.Hand", null)
                        .WithMany("Cards")
                        .HasForeignKey("HandId");
                });

            modelBuilder.Entity("Entities.Card", b =>
                {
                    b.Navigation("hand");
                });

            modelBuilder.Entity("Entities.Hand", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
