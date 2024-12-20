﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBurger.WebAPI.Context;

#nullable disable

namespace MyBurger.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240903082139_Id_columns_added_to_bridges")]
    partial class Id_columns_added_to_bridges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBurger.WebAPI.Models.BR_Menu_Product", b =>
                {
                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MenuId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BR_Menu_Product");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.BR_Product_Ingrediant", b =>
                {
                    b.Property<Guid>("IngrediantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngrediantId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BR_Product_Ingrediant");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Ingrediant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingrediants");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderedMenus");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenuProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderedMenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderedMenuId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedMenuProducts");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.UnorderedIngrediant", b =>
                {
                    b.Property<Guid>("IngrediantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderedMenuProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngrediantId", "OrderedMenuProductId");

                    b.HasIndex("OrderedMenuProductId");

                    b.ToTable("UnorderedIngrediants");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.BR_Menu_Product", b =>
                {
                    b.HasOne("MyBurger.WebAPI.Models.Menu", "Menu")
                        .WithMany("bR_Menu_Products")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBurger.WebAPI.Models.Product", "Product")
                        .WithMany("BR_Menu_Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.BR_Product_Ingrediant", b =>
                {
                    b.HasOne("MyBurger.WebAPI.Models.Ingrediant", "Ingrediant")
                        .WithMany("BR_Product_Ingrediants")
                        .HasForeignKey("IngrediantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBurger.WebAPI.Models.Product", "Product")
                        .WithMany("BR_Product_Ingrediants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediant");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenu", b =>
                {
                    b.HasOne("MyBurger.WebAPI.Models.Menu", "Menu")
                        .WithMany("OrderedMenu")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBurger.WebAPI.Models.Order", "Order")
                        .WithMany("OrderedMenu")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenuProduct", b =>
                {
                    b.HasOne("MyBurger.WebAPI.Models.OrderedMenu", "OrderedMenu")
                        .WithMany("OrderedMenuProduct")
                        .HasForeignKey("OrderedMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBurger.WebAPI.Models.Product", "Product")
                        .WithMany("OrderedMenuProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderedMenu");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.UnorderedIngrediant", b =>
                {
                    b.HasOne("MyBurger.WebAPI.Models.Ingrediant", "Ingrediant")
                        .WithMany("UnorderedIngrediant")
                        .HasForeignKey("IngrediantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBurger.WebAPI.Models.OrderedMenuProduct", "OrderedMenuProduct")
                        .WithMany("UnorderedIngrediant")
                        .HasForeignKey("OrderedMenuProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediant");

                    b.Navigation("OrderedMenuProduct");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Ingrediant", b =>
                {
                    b.Navigation("BR_Product_Ingrediants");

                    b.Navigation("UnorderedIngrediant");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Menu", b =>
                {
                    b.Navigation("OrderedMenu");

                    b.Navigation("bR_Menu_Products");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Order", b =>
                {
                    b.Navigation("OrderedMenu");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenu", b =>
                {
                    b.Navigation("OrderedMenuProduct");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.OrderedMenuProduct", b =>
                {
                    b.Navigation("UnorderedIngrediant");
                });

            modelBuilder.Entity("MyBurger.WebAPI.Models.Product", b =>
                {
                    b.Navigation("BR_Menu_Products");

                    b.Navigation("BR_Product_Ingrediants");

                    b.Navigation("OrderedMenuProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
