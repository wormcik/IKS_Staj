using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalamnamefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimHizmet_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet");

            migrationBuilder.DropTable(
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimHizmet_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet");

            migrationBuilder.DropColumn(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimHizmet_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatinAlmaBirimKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimHizmet_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatinAlmaBirimHizmet_SatinAlmaBirim_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet");

            migrationBuilder.DropIndex(
                name: "IX_SatinAlmaBirimHizmet_SatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet");

            migrationBuilder.AddColumn<int>(
                name: "SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma",
                columns: table => new
                {
                    SatınAlmaBirimPersonelKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelKod = table.Column<int>(type: "int", nullable: false),
                    SatınAlmaBirimSatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_SatinAlmaBirimPersonel_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                        column: x => x.SatınAlmaBirimSatinAlmaBirimKod,
                        principalSchema: "satinAlma",
                        principalTable: "SatinAlmaBirim",
                        principalColumn: "SatinAlmaBirimKod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimHizmet_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_PersonelKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "PersonelKod");

            migrationBuilder.CreateIndex(
                name: "IX_SatinAlmaBirimPersonel_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimPersonel",
                column: "SatınAlmaBirimSatinAlmaBirimKod");

            migrationBuilder.AddForeignKey(
                name: "FK_SatinAlmaBirimHizmet_SatinAlmaBirim_SatınAlmaBirimSatinAlmaBirimKod",
                schema: "satinAlma",
                table: "SatinAlmaBirimHizmet",
                column: "SatınAlmaBirimSatinAlmaBirimKod",
                principalSchema: "satinAlma",
                principalTable: "SatinAlmaBirim",
                principalColumn: "SatinAlmaBirimKod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
