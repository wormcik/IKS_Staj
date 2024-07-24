using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlimTalepOngorulenTurarAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OngorulenTutar",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "NUMERIC(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "KullanıcıKod",
                schema: "satinAlma",
                table: "Personel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OngorulenTutar",
                schema: "satinAlma",
                table: "SatinAlmaTalep");

            migrationBuilder.DropColumn(
                name: "KullanıcıKod",
                schema: "satinAlma",
                table: "Personel");
        }
    }
}
