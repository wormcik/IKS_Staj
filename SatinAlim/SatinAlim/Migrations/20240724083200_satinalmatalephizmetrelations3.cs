using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalmatalephizmetrelations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaHizmetKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepHizmet_SatinAlmaHizmet_SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaHizmetKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaHizmet",
                principalColumn: "SatinAlmaHizmetKod",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepHizmet_SatinAlmaHizmet_SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.DropColumn(
                name: "SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");
        }
    }
}
