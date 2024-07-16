using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userRoleTypes",
                schema: "yetki",
                columns: table => new
                {
                    UserRoleTypeId = table.Column<int>(type: "int", nullable: false),
                    UserTypeName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserRoleName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoleTypes", x => x.UserRoleTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userRoleTypes",
                schema: "yetki");
        }
    }
}
