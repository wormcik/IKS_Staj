using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class EntityNullableControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                type: "VARCHAR(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PbKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                type: "VARCHAR(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OngorulenTutarPbKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Birim",
                schema: "satinAlma",
                table: "SatinAlmaHizmet",
                type: "VARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaHizmet",
                type: "VARCHAR(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "SatinAlmaTalepDurumKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                type: "VARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaTalepTarihce",
                type: "VARCHAR(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "PbKod",
                schema: "satinAlma",
                table: "SatinAlmaTalepHizmet",
                type: "VARCHAR(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");

            migrationBuilder.AlterColumn<string>(
                name: "OngorulenTutarPbKod",
                schema: "satinAlma",
                table: "SatinAlmaTalep",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Birim",
                schema: "satinAlma",
                table: "SatinAlmaHizmet",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                schema: "satinAlma",
                table: "SatinAlmaHizmet",
                type: "VARCHAR(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
