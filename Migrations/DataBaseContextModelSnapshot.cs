﻿// <auto-generated />
using System;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommersShop.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommersShop.Entity.Cart.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ECommersShop.Entity.Cart.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<int>("PriceProduct")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ECommersShop.Entity.Finances.RequestPay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Authority")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsPay")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RefId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("RequestPays");
                });

            modelBuilder.Entity("ECommersShop.Entity.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderState")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RequestPayId")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("RequestPayId1")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestPayId1");

                    b.HasIndex("UserId1");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Displayed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Inventory")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.ProductInCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CategryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInCategories");
                });

            modelBuilder.Entity("ECommersShop.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommersShop.Entity.UserInRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("ECommersShop.Entity.Cart.Cart", b =>
                {
                    b.HasOne("ECommersShop.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommersShop.Entity.Cart.CartItem", b =>
                {
                    b.HasOne("ECommersShop.Entity.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommersShop.Entity.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommersShop.Entity.Finances.RequestPay", b =>
                {
                    b.HasOne("ECommersShop.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommersShop.Entity.Orders.Order", b =>
                {
                    b.HasOne("ECommersShop.Entity.Finances.RequestPay", "RequestPay")
                        .WithMany("Orders")
                        .HasForeignKey("RequestPayId1");

                    b.HasOne("ECommersShop.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("RequestPay");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.ProductInCategory", b =>
                {
                    b.HasOne("ECommersShop.Entity.Products.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("ECommersShop.Entity.Products.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommersShop.Entity.UserInRole", b =>
                {
                    b.HasOne("ECommersShop.Entity.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommersShop.Entity.Cart.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ECommersShop.Entity.Finances.RequestPay", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("ECommersShop.Entity.Products.Product", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("ECommersShop.Entity.User", b =>
                {
                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
