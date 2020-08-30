using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ecommerce.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "public",
                columns: table => new
                {
                    IdCategory = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "public",
                columns: table => new
                {
                    IdLog = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    MessageException = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    HelpLink = table.Column<string>(nullable: true),
                    HResult = table.Column<string>(nullable: true),
                    SourceException = table.Column<string>(nullable: true),
                    TargetSite = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "public",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "public",
                columns: table => new
                {
                    IdProduct = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCategory = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubHeader = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    ImgApproved = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Product_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalSchema: "public",
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "public",
                columns: table => new
                {
                    IdAddress = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Address_User_Email",
                        column: x => x.Email,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "public",
                columns: table => new
                {
                    IdCard = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    UsernameCard = table.Column<string>(nullable: true),
                    NumberCard = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<string>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_User_Email",
                        column: x => x.Email,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "public",
                columns: table => new
                {
                    IdCart = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Bought = table.Column<bool>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.IdCart);
                    table.ForeignKey(
                        name: "FK_Cart_User_Email",
                        column: x => x.Email,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "public",
                columns: table => new
                {
                    IdComment = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduct = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comment_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                schema: "public",
                columns: table => new
                {
                    IdCartDetail = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCart = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.IdCartDetail);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_IdCart",
                        column: x => x.IdCart,
                        principalSchema: "public",
                        principalTable: "Cart",
                        principalColumn: "IdCart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                schema: "public",
                columns: table => new
                {
                    IdPurchase = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    IdCart = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Purchase_User_Email",
                        column: x => x.Email,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Cart_IdCart",
                        column: x => x.IdCart,
                        principalSchema: "public",
                        principalTable: "Cart",
                        principalColumn: "IdCart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetailProductAuxiliaryNn",
                schema: "public",
                columns: table => new
                {
                    IdCartDetailProduct = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCartDetail = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetailProductAuxiliaryNn", x => x.IdCartDetailProduct);
                    table.ForeignKey(
                        name: "FK_CartDetailProductAuxiliaryNn_CartDetail_IdCartDetail",
                        column: x => x.IdCartDetail,
                        principalSchema: "public",
                        principalTable: "CartDetail",
                        principalColumn: "IdCartDetail",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetailProductAuxiliaryNn_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Email",
                schema: "public",
                table: "Address",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Email",
                schema: "public",
                table: "Card",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Email",
                schema: "public",
                table: "Cart",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IdCart",
                schema: "public",
                table: "CartDetail",
                column: "IdCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetailProductAuxiliaryNn_IdCartDetail",
                schema: "public",
                table: "CartDetailProductAuxiliaryNn",
                column: "IdCartDetail");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetailProductAuxiliaryNn_IdProduct",
                schema: "public",
                table: "CartDetailProductAuxiliaryNn",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdProduct",
                schema: "public",
                table: "Comment",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                schema: "public",
                table: "Product",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Email",
                schema: "public",
                table: "Purchase",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_IdCart",
                schema: "public",
                table: "Purchase",
                column: "IdCart",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CartDetailProductAuxiliaryNn",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Purchase",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CartDetail",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cart",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "public");

            migrationBuilder.DropTable(
                name: "User",
                schema: "public");
        }
    }
}
