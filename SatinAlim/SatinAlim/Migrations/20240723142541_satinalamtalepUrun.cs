using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalamtalepUrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepTarihces",
                schema: "satinAlma",
                newName: "SatinAlmaTalepTarihce",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_SatinAlmaTalepTarihce",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepTarihceKod");

            migrationBuilder.CreateTable(
                name: "SatinAlmaTalepUrun",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaTalepUrunKod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaTalepKod = table.Column<long>(type: "bigint", nullable: false),
                    Miktar = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false),
                    PbKod = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaTalepUrun", x => x.SatinAlmaTalepUrunKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalepUrun_SatinAlmaTalep_SatinAlmaTalepKod",
                        column: x => x.SatinAlmaTalepKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaTalep",
                        principalColumn: "SatinAlmaTalepKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepUrun_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
                column: "SatinAlmaTalepKod");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropTable(
                name: "SatinAlmaTalepUrun",
                schema: "satinAlma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SatinAlmaTalepTarihce",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.RenameTable(
                name: "SatinAlmaTalepTarihce",
                schema: "satinAlma",
                newName: "SatinAlmaTalepTarihces",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_SatinAlmaTalepTarihces",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihces",
                column: "SatinAlmaTalepTarihceKod");

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
    }
}
