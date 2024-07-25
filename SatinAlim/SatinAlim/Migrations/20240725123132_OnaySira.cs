using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class OnaySira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnaySıra",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "OnaySira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OnaySira",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "OnaySıra");
        }
    }
}
