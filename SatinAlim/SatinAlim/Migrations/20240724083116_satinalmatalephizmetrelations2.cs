using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalmatalephizmetrelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                newName: "SatinAlmaTalepHizmetKod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SatinAlmaTalepHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                newName: "SatinAlmaHizmetKod");
        }
    }
}
