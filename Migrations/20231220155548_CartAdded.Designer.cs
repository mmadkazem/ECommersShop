﻿// <auto-generated />
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommersShop.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231220155548_CartAdded")]
    partial class CartAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
