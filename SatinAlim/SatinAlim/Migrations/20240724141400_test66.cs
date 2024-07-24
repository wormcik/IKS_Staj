using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class test66 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimOnayci_Personel_OnayPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimUrun_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalep_Personel_TalepPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimUrun_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun");

            migrationBuilder.DropColumn(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun");

            migrationBuilder.RenameColumn(
                name: "TalepPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                newName: "PersonelKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalep_TalepPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                newName: "IX_SatinAlmaTalep_PersonelKod");

            migrationBuilder.RenameColumn(
                name: "OnayPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "PersonelKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaBirimOnayci_OnayPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "IX_SatinAlmaBirimOnayci_PersonelKod");

            migrationBuilder.AddColumn<Guid>(
                name: "KullaniciKod",
                schema: "satinAlma",
                table: "Personel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimUrun_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatinAlmaBirimKod");

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
                name: "FK_SatinAlmaBirimUrun_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimOnayci_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimUrun_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun");

            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaTalep_Personel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimUrun_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun");

            migrationBuilder.DropColumn(
                name: "KullaniciKod",
                schema: "satinAlma",
                table: "Personel");

            migrationBuilder.RenameColumn(
                name: "PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                newName: "TalepPersonelKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaTalep_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                newName: "IX_SatinAlmaTalep_TalepPersonelKod");

            migrationBuilder.RenameColumn(
                name: "PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "OnayPersonelKod");

            migrationBuilder.RenameIndex(
                name: "IX_SatinAlmaBirimOnayci_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                newName: "IX_SatinAlmaBirimOnayci_OnayPersonelKod");

            migrationBuilder.AddColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimUrun_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimOnayci_Personel_OnayPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimOnayci",
                column: "OnayPersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimUrun_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatınAlmaBirimSatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaTalep_Personel_TalepPersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                column: "TalepPersonelKod",
                principalSchema: "satinAlma",
                principalTable: "Personel",
                principalColumn: "PersonelKod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
