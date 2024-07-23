using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlimTalepDurumRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetSatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalep_GetSatinAlmaTalepDurum_SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_GetSatinAlmaTalepDurum_SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropTable(
                name: "GetSatinAlmaTalepDurum",
                schema: "satinAlma");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalep_SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SatinAlmaTalepTarihce",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet");

            migrationBuilder.DropColumn(
                name: "SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropColumn(
                name: "SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepTarihce",
                schema: "satinAlma",
                newName: "SatinAlmaTalepTarihces",
                newSchema: "satinAlma");

            migrationBuilder.RenameTable(
                name: "GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                newName: "SatinAlmaTalepHizmet",
                newSchema: "satinAlma");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
                newName: "IX_SatinAlmaTalepTarihces_SatinAlmaTalepKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalepTarihce_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
                newName: "IX_SatinAlmaTalepTarihces_PersonelKod");

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
                name: "PK_SatinAlmaTalepTarihces",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
                column: "SatinAlmaTalepTarihceKod");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepTarihces_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
                column: "PersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepTarihces_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
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
                name: "FK_SatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihces_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihces_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SatinAlmaTalepTarihces",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepTarihces",
                schema: "satinAlma",
                newName: "SatinAlmaTalepTarihce",
                newSchema: "satinAlma");

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepHizmet",
                schema: "satinAlma",
                newName: "GetSatinAlmaTalepHizmet",
                newSchema: "satinAlma");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalepTarihces_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                newName: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalepTarihces_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                newName: "IX_SatinAlmaTalepTarihce_PersonelKod");

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

            migrationBuilder.AddColumn<string>(
                name: "SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SatinAlmaTalepTarihce",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepTarihceKod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetSatinAlmaTalepHizmet",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                column: "SatinAlmaTalepHizmetKod");

            migrationBuilder.CreateTable(
                name: "GetSatinAlmaTalepDurum",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaTalepDurumKod = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetSatinAlmaTalepDurum", x => x.SatinAlmaTalepDurumKod);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "SatinalmaTalepDurumKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepDurumKod");

            migrationBuilder.AddForeignKey(
                name: "FK_GetSatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "GetSatinAlmaTalepHizmet",
                column: "SatinAlmaTalepKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaTalep",
                principalColumn: "SatinAlmaTalepKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalep_GetSatinAlmaTalepDurum_SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "SatinalmaTalepDurumKod",
                principalSchema: "satinAlma",
                principalTable: "GetSatinAlmaTalepDurum",
                principalColumn: "SatinAlmaTalepDurumKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepTarihce_GetSatinAlmaTalepDurum_SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepDurumKod",
                principalSchema: "satinAlma",
                principalTable: "GetSatinAlmaTalepDurum",
                principalColumn: "SatinAlmaTalepDurumKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepTarihce_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "PersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaTalep",
                principalColumn: "SatinAlmaTalepKod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
