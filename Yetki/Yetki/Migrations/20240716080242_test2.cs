using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                schema: "yetki",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "yetki",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                schema: "yetki",
                table: "Users",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                schema: "yetki",
                table: "Users");
        }
    }
}
