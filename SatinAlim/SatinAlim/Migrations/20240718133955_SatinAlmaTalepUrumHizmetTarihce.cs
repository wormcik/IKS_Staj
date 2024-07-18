using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlmaTalepUrumHizmetTarihce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tanim",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Birim",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)");

            migrationBuilder.CreateTable(
                name: "SatinAlmaTalep",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaTalepKod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    SatinalmaTalepDurumKod = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    TalepPersonelKod = table.Column<int>(type: "int", nullable: false),
                    TalepTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    OngorulenTutarPbKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "VARCHAR(8000)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnaySira = table.Column<int>(type: "int", nullable: false),
                    IslemTarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaTalep", x => x.SatinAlmaTalepKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalep_GetSatinAlmaTalepDurum_SatinalmaTalepDurumKod",
                        column: x => x.SatinalmaTalepDurumKod,
                        principalSchema: "satinAlma",
                        principalTable: "GetSatinAlmaTalepDurum",
                        principalColumn: "SatinAlmaTalepDurumKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalep_Personel_TalepPersonelKod",
                        column: x => x.TalepPersonelKod,
                        principalSchema: "satinAlma",
                        principalTable: "Personel",
                        principalColumn: "PersonelKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalep_SatinAlmaBirim_SatinAlmaBirimKod",
                        column: x => x.SatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaTalepHizmet",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaHizmetKod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaTalepKod = table.Column<long>(type: "bigint", nullable: false),
                    Miktar = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false),
                    PbKod = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    BirimFiyat = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaTalepHizmet", x => x.SatinAlmaHizmetKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalepHizmet_SatinAlmaTalep_SatinAlmaTalepKod",
                        column: x => x.SatinAlmaTalepKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaTalep",
                        principalColumn: "SatinAlmaTalepKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaTalepTarihce",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaTalepTarihceKod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaTalepKod = table.Column<long>(type: "bigint", nullable: false),
                    PersonelKod = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaTalepDurumKod = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    OnaySira = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "VARCHAR(2000)", nullable: true),
                    IslemTarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaTalepTarihce", x => x.SatinAlmaTalepTarihceKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalepTarihce_GetSatinAlmaTalepDurum_SatinAlmaTalepDurumKod",
                        column: x => x.SatinAlmaTalepDurumKod,
                        principalSchema: "satinAlma",
                        principalTable: "GetSatinAlmaTalepDurum",
                        principalColumn: "SatinAlmaTalepDurumKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalepTarihce_Personel_PersonelKod",
                        column: x => x.PersonelKod,
                        principalSchema: "satinAlma",
                        principalTable: "Personel",
                        principalColumn: "PersonelKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                        column: x => x.SatinAlmaTalepKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaTalep",
                        principalColumn: "SatinAlmaTalepKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "SatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_SatinalmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "SatinalmaTalepDurumKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_TalepPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "TalepPersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaTalepKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepDurumKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepKod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatinAlmaTalepHizmet",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaTalepTarihce",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaTalep",
                schema: "satinAlma");

            migrationBuilder.AlterColumn<string>(
                name: "Tanim",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Birim",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaUrun",
                type: "VARCHAR(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)",
                oldNullable: true);
        }
    }
}
