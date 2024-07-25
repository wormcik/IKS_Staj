using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatinAlim.Migrations
{
    /// <inheritdoc />
    public partial class satinalamnamefix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma",
                columns: table => new
                {
                    SatinAlmaBirimPersonelKod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatinAlmaBirimKod = table.Column<int>(type: "int", nullable: false),
                    PersonelKod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatinAlmaBirimPersonel", x => x.SatinAlmaBirimPersonelKod);
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
                name: "SatinAlmaBirimPersonel",
                schema: "satinAlma");
        }
    }
}
