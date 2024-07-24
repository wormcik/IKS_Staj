using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class talepekle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SatinAlmaTalep",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaTalepKod = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    PersonelKod = table.Column<int>(type: "int", nullable: false),
                    TalepTarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    OngorulenTutar = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false),
                    OngorulenTutarPbKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "VARCHAR(8000)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnaySira = table.Column<int>(type: "int", nullable: false),
                    IslemTarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaTalep", x => x.SatinAlmaTalepKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaTalep_Personel_PersonelKod",
                        column: x => x.PersonelKod,
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

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepUrun_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
                column: "SatinAlmaTalepKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                column: "SatinAlmaTalepKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaTalep_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "SatinAlmaBirimKod");

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
                name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                column: "SatinAlmaTalepKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaTalep",
                principalColumn: "SatinAlmaTalepKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalepUrun_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun",
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
                name: "FK_SatinAlmaTalepTarihce_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalepUrun_SatinAlmaTalep_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun");

            migrationBuilder.DropTable(
                name: "SatinAlmaTalep",
                schema: "satinAlma");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepUrun_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepUrun");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepTarihce_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaTalepHizmet_SatinAlmaTalepKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet");
        }
    }
}
