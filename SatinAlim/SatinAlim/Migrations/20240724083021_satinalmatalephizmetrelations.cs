using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalmatalephizmetrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepUrun_SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
                column: "SatinAlmaUrunKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepUrun_SatinAlmaUrun_SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
                column: "SatinAlmaUrunKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaUrun",
                principalColumn: "SatinAlmaUrunKod",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepUrun_SatinAlmaUrun_SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepUrun_SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun");

            migrationBuilder.DropColumn(
                name: "SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun");
        }
    }
}
