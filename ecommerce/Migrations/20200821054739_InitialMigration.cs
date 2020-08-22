using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ecommerce.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCategory = table.Column<int>(nullable: false),
                    CategoryIdCategory = table.Column<int>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubHeader = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryIdCategory",
                        column: x => x.CategoryIdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Address_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    UsernameCard = table.Column<string>(nullable: true),
                    NumberCard = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<string>(nullable: true),
                    Cvc = table.Column<string>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    IdCart = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.IdCart);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    IdLog = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    MessageException = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    HelpLink = table.Column<string>(nullable: true),
                    HResult = table.Column<string>(nullable: true),
                    SourceException = table.Column<string>(nullable: true),
                    TargetSite = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.IdLog);
                    table.ForeignKey(
                        name: "FK_Log_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    IdComment = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduct = table.Column<int>(nullable: false),
                    ProductIdProduct = table.Column<int>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comment_Product_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    IdCartDetail = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCart = table.Column<int>(nullable: false),
                    CartIdCart = table.Column<int>(nullable: true),
                    IdProduct = table.Column<int>(nullable: false),
                    ProductIdProduct = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.IdCartDetail);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_CartIdCart",
                        column: x => x.CartIdCart,
                        principalTable: "Cart",
                        principalColumn: "IdCart",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartDetail_Product_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    IdPurchase = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCart = table.Column<int>(nullable: false),
                    CartIdCart = table.Column<int>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Purchase_Cart_CartIdCart",
                        column: x => x.CartIdCart,
                        principalTable: "Cart",
                        principalColumn: "IdCart",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserEmail",
                table: "Address",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserEmail",
                table: "Card",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserEmail",
                table: "Cart",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_CartIdCart",
                table: "CartDetail",
                column: "CartIdCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductIdProduct",
                table: "CartDetail",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductIdProduct",
                table: "Comment",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserEmail",
                table: "Log",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryIdCategory",
                table: "Product",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CartIdCart",
                table: "Purchase",
                column: "CartIdCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
