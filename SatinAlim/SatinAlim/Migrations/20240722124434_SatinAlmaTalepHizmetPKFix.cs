using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlmaTalepHizmetPKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepHizmet",
                schema: "satinAlma",
                newName: "GetSatinAlmaTalepHizmet",
                newSchema: "satinAlma");

            migrationBuilder.RenameColumn(
                name: "SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                newName: "SatinAlmaTalepHizmetKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                newName: "IX_GetSatinAlmaTalepHizmet_SatinAlmaTalepKod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                column: "SatinAlmaTalepHizmetKod");

            migrationBuilder.AddForeignKey(
                name: "FK_GetSatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                column: "SatinAlmaTalepKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaTalep",
                principalColumn: "SatinAlmaTalepKod",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetSatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet");

            migrationBuilder.RenameTable(
                name: "GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                newName: "SatinAlmaTalepHizmet",
                newSchema: "satinAlma");

            migrationBuilder.RenameColumn(
                name: "SatinAlmaTalepHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                newName: "SatinAlmaHizmetKod");

            migrationBuilder.RenameIndex(
                name: "IX_GetSatinAlmaTalepHizmet_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                newName: "IX_SatinAlmaTalepHizmet_SatinAlmaTalepKod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaHizmetKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaTalepKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaTalep",
                principalColumn: "SatinAlmaTalepKod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
