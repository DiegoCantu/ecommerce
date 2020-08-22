﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ecommerce.Persistence;

namespace ecommerce.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20200821054739_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ecommerce.Models.Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BuyerName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("InUse")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("IdAddress");

                    b.HasIndex("UserEmail");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ecommerce.Models.Card", b =>
                {
                    b.Property<int>("IdCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CardName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Cvc")
                        .HasColumnType("text");

                    b.Property<string>("ExpireDate")
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("InUse")
                        .HasColumnType("boolean");

                    b.Property<string>("NumberCard")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.Property<string>("UsernameCard")
                        .HasColumnType("text");

                    b.HasKey("IdCard");

                    b.HasIndex("UserEmail");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("ecommerce.Models.Cart", b =>
                {
                    b.Property<int>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("IdCart");

                    b.HasIndex("UserEmail");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ecommerce.Models.CartDetail", b =>
                {
                    b.Property<int>("IdCartDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CartIdCart")
                        .HasColumnType("integer");

                    b.Property<int>("IdCart")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductIdProduct")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("IdCartDetail");

                    b.HasIndex("CartIdCart");

                    b.HasIndex("ProductIdProduct");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("ecommerce.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("IdCategory");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ecommerce.Models.Comment", b =>
                {
                    b.Property<int>("IdComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Post")
                        .HasColumnType("text");

                    b.Property<int?>("ProductIdProduct")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("IdComment");

                    b.HasIndex("ProductIdProduct");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ecommerce.Models.Log", b =>
                {
                    b.Property<int>("IdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("HResult")
                        .HasColumnType("text");

                    b.Property<string>("HelpLink")
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("InnerException")
                        .HasColumnType("text");

                    b.Property<string>("MessageException")
                        .HasColumnType("text");

                    b.Property<string>("SourceException")
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .HasColumnType("text");

                    b.Property<string>("TargetSite")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("IdLog");

                    b.HasIndex("UserEmail");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CategoryIdCategory")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("IdCategory")
                        .HasColumnType("integer");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<string>("SubHeader")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("IdProduct");

                    b.HasIndex("CategoryIdCategory");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ecommerce.Models.Purchase", b =>
                {
                    b.Property<int>("IdPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CartIdCart")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdCart")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("IdPurchase");

                    b.HasIndex("CartIdCart");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("ecommerce.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ecommerce.Models.Address", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("ecommerce.Models.Card", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("ecommerce.Models.Cart", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("ecommerce.Models.CartDetail", b =>
                {
                    b.HasOne("ecommerce.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartIdCart");

                    b.HasOne("ecommerce.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductIdProduct");
                });

            modelBuilder.Entity("ecommerce.Models.Comment", b =>
                {
                    b.HasOne("ecommerce.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductIdProduct");
                });

            modelBuilder.Entity("ecommerce.Models.Log", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.HasOne("ecommerce.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryIdCategory");
                });

            modelBuilder.Entity("ecommerce.Models.Purchase", b =>
                {
                    b.HasOne("ecommerce.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartIdCart");
                });
#pragma warning restore 612, 618
        }
    }
}
