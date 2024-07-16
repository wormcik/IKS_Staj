using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userRoleTypes",
                schema: "yetki",
                table: "userRoleTypes");

            migrationBuilder.RenameTable(
                name: "userRoleTypes",
                schema: "yetki",
                newName: "UserRoleTypes",
                newSchema: "yetki");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleTypes",
                schema: "yetki",
                table: "UserRoleTypes",
                column: "UserRoleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleTypes",
                schema: "yetki",
                table: "UserRoleTypes");

            migrationBuilder.RenameTable(
                name: "UserRoleTypes",
                schema: "yetki",
                newName: "userRoleTypes",
                newSchema: "yetki");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userRoleTypes",
                schema: "yetki",
                table: "userRoleTypes",
                column: "UserRoleTypeId");
        }
    }
}
