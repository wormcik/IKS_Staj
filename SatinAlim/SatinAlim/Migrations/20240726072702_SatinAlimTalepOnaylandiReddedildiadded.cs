using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlimTalepOnaylandiReddedildiadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Onaylandi",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reddedildi",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Onaylandi",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropColumn(
                name: "Reddedildi",
                schema: "satinAlma",
                table: "SatinAlmaTalep");
        }
    }
}
