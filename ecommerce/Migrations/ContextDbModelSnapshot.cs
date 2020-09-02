﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ecommerce.Persistence;

namespace ecommerce.Migrations
{
    [DbContext(typeof(ContextDb))]
    partial class ContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("InUse")
                        .HasColumnType("boolean");

                    b.Property<string>("Indications")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("Suburb")
                        .HasColumnType("text");

                    b.HasKey("IdAddress");

                    b.HasIndex("Email");

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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ExpireDate")
                        .HasColumnType("text");

                    b.Property<bool>("InUse")
                        .HasColumnType("boolean");

                    b.Property<string>("NumberCard")
                        .HasColumnType("text");

                    b.Property<string>("UsernameCard")
                        .HasColumnType("text");

                    b.HasKey("IdCard");

                    b.HasIndex("Email");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("ecommerce.Models.Cart", b =>
                {
                    b.Property<int>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Bought")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("IdCart");

                    b.HasIndex("Email");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ecommerce.Models.CartDetail", b =>
                {
                    b.Property<int>("IdCartDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdCart")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("IdCartDetail");

                    b.HasIndex("IdCart");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("ecommerce.Models.CartDetailProductAuxiliaryNn", b =>
                {
                    b.Property<int>("IdCartDetailProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdCartDetail")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.HasKey("IdCartDetailProduct");

                    b.HasIndex("IdCartDetail");

                    b.HasIndex("IdProduct");

                    b.ToTable("CartDetailProductAuxiliaryNn");
                });

            modelBuilder.Entity("ecommerce.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Post")
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.HasKey("IdComment");

                    b.HasIndex("IdProduct");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ecommerce.Models.Log", b =>
                {
                    b.Property<int>("IdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HResult")
                        .HasColumnType("text");

                    b.Property<string>("HelpLink")
                        .HasColumnType("text");

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

                    b.HasKey("IdLog");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("IdCategory")
                        .HasColumnType("integer");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<bool>("ImgApproved")
                        .HasColumnType("boolean");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<string>("SubHeader")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCategory");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ecommerce.Models.Purchase", b =>
                {
                    b.Property<int>("IdPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("IdCart")
                        .HasColumnType("integer");

                    b.HasKey("IdPurchase");

                    b.HasIndex("Email");

                    b.HasIndex("IdCart")
                        .IsUnique();

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("ecommerce.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ecommerce.Models.Address", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Address")
                        .HasForeignKey("Email");
                });

            modelBuilder.Entity("ecommerce.Models.Card", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Card")
                        .HasForeignKey("Email");
                });

            modelBuilder.Entity("ecommerce.Models.Cart", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("Email");
                });

            modelBuilder.Entity("ecommerce.Models.CartDetail", b =>
                {
                    b.HasOne("ecommerce.Models.Cart", "Cart")
                        .WithMany("CartDetail")
                        .HasForeignKey("IdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ecommerce.Models.CartDetailProductAuxiliaryNn", b =>
                {
                    b.HasOne("ecommerce.Models.CartDetail", "CartDetail")
                        .WithMany("CartDetailProductAuxiliaryNn")
                        .HasForeignKey("IdCartDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce.Models.Product", "Product")
                        .WithMany("CartDetailProductAuxiliaryNn")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ecommerce.Models.Comment", b =>
                {
                    b.HasOne("ecommerce.Models.Product", "Product")
                        .WithMany("Comment")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.HasOne("ecommerce.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ecommerce.Models.Purchase", b =>
                {
                    b.HasOne("ecommerce.Models.User", "User")
                        .WithMany("Purchase")
                        .HasForeignKey("Email");

                    b.HasOne("ecommerce.Models.Cart", "Cart")
                        .WithOne("Purchase")
                        .HasForeignKey("ecommerce.Models.Purchase", "IdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
