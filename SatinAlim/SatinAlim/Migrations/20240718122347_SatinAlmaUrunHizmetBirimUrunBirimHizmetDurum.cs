using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class SatinAlmaUrunHizmetBirimUrunBirimHizmetDurum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimPersonel_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.AddColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "SatinAlmaHizmet",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaHizmetKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Aciklama = table.Column<string>(type: "VARCHAR(2000)", nullable: false),
                    Birim = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaHizmet", x => x.SatinAlmaHizmetKod);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaUrun",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaUrunKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Aciklama = table.Column<string>(type: "VARCHAR(2000)", nullable: false),
                    Birim = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaUrun", x => x.SatinAlmaUrunKod);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimHizmet",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaBirimHizmetKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaHizmetKod = table.Column<int>(type: "int", nullable: false),
                    SatınAlmaBirimSatinAlmaBirimKod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirimHizmet", x => x.SatinAlmaBirimHizmetKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimHizmet_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                        column: x => x.SatınAlmaBirimSatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimHizmet_SatinAlmaHizmet_SatinAlmaHizmetKod",
                        column: x => x.SatinAlmaHizmetKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaHizmet",
                        principalColumn: "SatinAlmaHizmetKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimUrun",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaBirimUrunKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaUrunKod = table.Column<int>(type: "int", nullable: false),
                    SatınAlmaBirimSatinAlmaBirimKod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirimUrun", x => x.SatinAlmaBirimUrunKod);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimUrun_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                        column: x => x.SatınAlmaBirimSatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SatinAlmaBirimUrun_SatinAlmaUrun_SatinAlmaUrunKod",
                        column: x => x.SatinAlmaUrunKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaUrun",
                        principalColumn: "SatinAlmaUrunKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimHizmet_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimHizmet_SatinAlmaHizmetKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatinAlmaHizmetKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimUrun_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimUrun_SatinAlmaUrunKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimUrun",
                column: "SatinAlmaUrunKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatınAlmaBirimSatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.DropTable(
                name: "GetSatinAlmaTalepDurum",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaBirimHizmet",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaBirimUrun",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaHizmet",
                schema: "satinAlma");

            migrationBuilder.DropTable(
                name: "SatinAlmaUrun",
                schema: "satinAlma");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimPersonel_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.DropColumn(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatinAlmaBirimKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
