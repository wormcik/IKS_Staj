using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class testongorulentutar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OngorulenTutarTest",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "NUMERIC(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OngorulenTutarTest",
                schema: "satinAlma",
                table: "SatinAlmaTalep");
        }
    }
}
