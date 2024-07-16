using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "yetki");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "yetki",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "yetki");
        }
    }
}
