using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class deneme3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "satinAlma");

            migrationBuilder.RenameTable(
                name: "TestProducts",
                newName: "TestProducts",
                newSchema: "satinAlma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TestProducts",
                schema: "satinAlma",
                newName: "TestProducts");
        }
    }
}
