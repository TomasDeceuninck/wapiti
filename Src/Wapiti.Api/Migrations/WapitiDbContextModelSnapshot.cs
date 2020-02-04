﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wapiti.Persistence;

namespace Wapiti.Api.Migrations
{
    [DbContext(typeof(WapitiDbContext))]
    partial class WapitiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Wapiti.Domain.Entities.Card", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.CollectionCard", b =>
                {
                    b.Property<Guid>("CollectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.HasKey("CollectionId", "CardName");

                    b.HasIndex("CardName");

                    b.ToTable("CollectionCards");
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.Deck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.DeckCard", b =>
                {
                    b.Property<Guid>("DeckId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.HasKey("DeckId", "CardName");

                    b.HasIndex("CardName");

                    b.ToTable("DeckCards");
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.CollectionCard", b =>
                {
                    b.HasOne("Wapiti.Domain.Entities.Card", "Card")
                        .WithMany("CollectionCards")
                        .HasForeignKey("CardName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wapiti.Domain.Entities.Collection", "Collection")
                        .WithMany("Cards")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.Deck", b =>
                {
                    b.HasOne("Wapiti.Domain.Entities.Collection", "Collection")
                        .WithMany("Decks")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wapiti.Domain.Entities.DeckCard", b =>
                {
                    b.HasOne("Wapiti.Domain.Entities.Card", "Card")
                        .WithMany("DeckCards")
                        .HasForeignKey("CardName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wapiti.Domain.Entities.Deck", "Deck")
                        .WithMany("DeckList")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
