using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestProducts",
                schema: "satinAlma");

            migrationBuilder.CreateTable(
                name: "Personel",
                schema: "satinAlma",
                columns: table => new
                {
                    PersonelKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Soyad = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Pozisyon = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PersonelKod);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirim",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAd = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    OnaySayi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirim", x => x.SatinAlmaBirimKod);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimOnayci",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaBirimOnayciKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    OnayPersonelKod = table.Column<int>(type: "int", nullable: false),
                    OnaySıra = table.Column<int>(type: "int", nullable: false),
                    Sureli = table.Column<bool>(type: "bit", nullable: false),
                    BaslangicTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirimOnayci", x => x.SatinAlmaBirimOnayciKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimOnayci_Personel_OnayPersonelKod",
                        column: x => x.OnayPersonelKod,
                        principalSchema: "satinAlma",
                        principalTable: "Personel",
                        principalColumn: "PersonelKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimOnayci_SatinAlmaBirim_SatinAlmaBirimKod",
                        column: x => x.SatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma",
                columns: table => new
                {
                    SatınAlmaBirimPersonelKod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    PersonelKod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirimPersonel", x => x.SatınAlmaBirimPersonelKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimPersonel_Personel_PersonelKod",
                        column: x => x.PersonelKod,
                        principalSchema: "satinAlma",
                        principalTable: "Personel",
                        principalColumn: "PersonelKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatinAlmaBirimKod",
                        column: x => x.SatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimOnayci_OnayPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                column: "OnayPersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimOnayci_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                column: "SatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatinAlmaBirimKod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatinAlmaBirimOnayci",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "Personel",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaBirim",
                schema: "satinAlma");

            migrationBuilder.CreateTable(
                name: "TestProducts",
                schema: "satinAlma",
                columns: table => new
                {
                    TestProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProducts", x => x.TestProductID);
                });
        }
    }
}
