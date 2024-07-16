using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class test7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "yetki",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "UpdatedDate",
                schema: "yetki",
                table: "Users",
                type: "timestamp",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "yetki",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "RegistrationDate",
                schema: "yetki",
                table: "Users",
                type: "timestamp",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
