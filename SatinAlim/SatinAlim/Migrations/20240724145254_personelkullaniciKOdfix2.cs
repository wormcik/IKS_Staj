using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class personelkullaniciKOdfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimOnayci_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimPersonel_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalep_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepTarihce_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropTable(
                name: "Personel",
                schema: "satinAlma");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepTarihce_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalep_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimPersonel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimOnayci_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personel",
                schema: "satinAlma",
                columns: table => new
                {
                    PersonelKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Pozisyon = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Soyad = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PersonelKod);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimOnayci_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                column: "PersonelKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimOnayci_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                column: "PersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimPersonel_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "PersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalep_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "PersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
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
        }
    }
}
