﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220413092437_ShoppingCartAdded")]
    partial class ShoppingCartAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCartApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Bakery",
                            Description = "Bakery Products"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Vegetables",
                            Description = "All Vegetables"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Fruits",
                            Description = "All Fruits"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Drinks",
                            Description = "All Drinks"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Meat",
                            Description = "All Meat"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Snacks",
                            Description = "All Snacks"
                        });
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "The products prepared in the oven can contain as ingredients or as traces the following allergens: gluten, crustaceans shellfish, eggs, fish, peanuts, soybean, milk and dairy products, tree nuts, celery, mustard, sesame, sulphites, lupin and molluscan shellfish.",
                            Name = "Rustic Bread",
                            Price = 1.45m,
                            ShortDescription = "Rustic Bread"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = "Dulcita cherry on the vine tomatoes",
                            Name = "Cherry Tomatoes",
                            Price = 2.69m,
                            ShortDescription = "Cherry Tomatoes"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = " ",
                            Name = "Golden Apple",
                            Price = 0.38m,
                            ShortDescription = "Piece 210 g approx. | 1,79 €/kg"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = " ",
                            Name = "Coca-Cola",
                            Price = 1.84m,
                            ShortDescription = "Coca-Cola soft drink, 2L"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 5,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = " ",
                            Name = "Fleshy chunks pork ribs",
                            Price = 3.54m,
                            ShortDescription = "Tray 530 g approx. | 6,67 €/kg"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 6,
                            ImageUrl = "",
                            InStock = true,
                            LongDescription = " ",
                            Name = "Lay's Ready salted crisps",
                            Price = 1.48m,
                            ShortDescription = "Package 207 g | 7,15 €/kg"
                        });
                });

            modelBuilder.Entity("ShoppingCartApp.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Product", b =>
                {
                    b.HasOne("ShoppingCartApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCartApp.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("ShoppingCartApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
