using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordPolicyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(88)",
                maxLength: 88,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(86)",
                oldMaxLength: 86,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MustChangePassword",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordChangedOn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MustChangePassword", "PasswordChangedOn" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MustChangePassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordChangedOn",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(86)",
                maxLength: 86,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(88)",
                oldMaxLength: 88,
                oldNullable: true);
        }
    }
}
