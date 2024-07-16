using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yetki.Migrations
{
    /// <inheritdoc />
    public partial class test6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProcessCode",
                schema: "yetki",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RegistrationDate",
                schema: "yetki",
                table: "Users",
                type: "timestamp",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "RegistrationUserCode",
                schema: "yetki",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationUserName",
                schema: "yetki",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserCode",
                schema: "yetki",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserName",
                schema: "yetki",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessCode",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationUserCode",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationUserName",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateUserCode",
                schema: "yetki",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateUserName",
                schema: "yetki",
                table: "Users");
        }
    }
}
