using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "yetki",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UpdatedDate",
                schema: "yetki",
                table: "Users",
                type: "timestamp",
                nullable: true);
        }
    }
}
