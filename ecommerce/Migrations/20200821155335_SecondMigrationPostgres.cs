using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce.Migrations
{
    public partial class SecondMigrationPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_User_UserEmail",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_UserEmail",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Log",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Log",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserEmail",
                table: "Log",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_User_UserEmail",
                table: "Log",
                column: "UserEmail",
                principalTable: "User",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
