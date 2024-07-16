using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "yetki");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "yetki",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleTypes",
                schema: "yetki",
                columns: table => new
                {
                    UserRoleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UserRoleName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleTypes", x => x.UserRoleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "yetki",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Removed = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationUserCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegistrationUserName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserName = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ProcessCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                schema: "yetki",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.TypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "yetki");

            migrationBuilder.DropTable(
                name: "UserRoleTypes",
                schema: "yetki");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "yetki");

            migrationBuilder.DropTable(
                name: "UserTypes",
                schema: "yetki");
        }
    }
}
