﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieLand.Infrastructure.Database.Configuration;

#nullable disable

namespace MovieLand.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230427220226_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MovieLand.Application.Models.Category", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("category", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("MovieLand.Application.Models.Movie", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("INTEGER")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2049)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("FileId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT")
                        .HasColumnName("file_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<long?>("PriceId")
                        .IsRequired()
                        .HasColumnType("INTEGER")
                        .HasColumnName("price_id");

                    b.Property<int>("Quanitity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(2)
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PriceId")
                        .IsUnique();

                    b.ToTable("movie", "dbo");
                });

            modelBuilder.Entity("MovieLand.Application.Models.Price", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("REAL")
                        .HasColumnName("amount");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT")
                        .HasColumnName("currency");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("price", "dbo");
                });

            modelBuilder.Entity("MovieLand.Application.Models.ShoppingCart", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT")
                        .HasColumnName("currency");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0)
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("REAL")
                        .HasColumnName("total_price");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("shopping_cart", "dbo");
                });

            modelBuilder.Entity("MovieLand.Application.Models.ShoppingCartItem", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("MovieId")
                        .IsRequired()
                        .HasColumnType("INTEGER")
                        .HasColumnName("movie_id");

                    b.Property<long?>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("INTEGER")
                        .HasColumnName("shopping_cart_id");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("shopping_cart_item", "dbo");
                });

            modelBuilder.Entity("MovieLand.Application.Models.Movie", b =>
                {
                    b.HasOne("MovieLand.Application.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieLand.Application.Models.Price", "Price")
                        .WithOne("movie")
                        .HasForeignKey("MovieLand.Application.Models.Movie", "PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("MovieLand.Application.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("MovieLand.Application.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieLand.Application.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("MovieLand.Application.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieLand.Application.Models.Price", b =>
                {
                    b.Navigation("movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieLand.Application.Models.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}