using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UserHashAndSaltValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ParentCategories",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Incomes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Expenses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChildCategories",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ParentCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ChildCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 5, 14, 7, 57, DateTimeKind.Utc).AddTicks(8604));
        }
    }
}
