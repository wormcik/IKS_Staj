using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class test13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                schema: "yetki",
                table: "UserTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleTypes",
                schema: "yetki",
                table: "UserRoleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "yetki",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                schema: "yetki",
                newName: "UserType",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "yetki",
                newName: "User",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "UserRoleTypes",
                schema: "yetki",
                newName: "UserRoleType",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "yetki",
                newName: "UserRole",
                newSchema: "yetki");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                schema: "yetki",
                table: "UserType",
                column: "TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "yetki",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleType",
                schema: "yetki",
                table: "UserRoleType",
                column: "UserRoleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                schema: "yetki",
                table: "UserRole",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                schema: "yetki",
                table: "UserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleType",
                schema: "yetki",
                table: "UserRoleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                schema: "yetki",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "yetki",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserType",
                schema: "yetki",
                newName: "UserTypes",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "UserRoleType",
                schema: "yetki",
                newName: "UserRoleTypes",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "yetki",
                newName: "UserRoles",
                newSchema: "yetki");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "yetki",
                newName: "Users",
                newSchema: "yetki");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                schema: "yetki",
                table: "UserTypes",
                column: "TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleTypes",
                schema: "yetki",
                table: "UserRoleTypes",
                column: "UserRoleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "yetki",
                table: "UserRoles",
                column: "UserRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "yetki",
                table: "Users",
                column: "UserID");
        }
    }
}
