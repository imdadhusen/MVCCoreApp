using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Migrations
{
    /// <inheritdoc />
    public partial class PasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 6, 28, 16, 21, 37, 207, DateTimeKind.Utc).AddTicks(4374), "1vMi372tmTXw2LgItnQRh9bvTS88Am8ob0wfInqrdBXIV+1sIdcsw4j+48P2rUP2Kyt+UazOik1Yoflvdx+EwQ==", "xw6EbrRY1TTO1ef1Hclk4zFtWbfcHnTZgaw/K9+n05wYIKlaywZyRmn9VC0vGzklp1JaSQjtKoI0Wmf6FgUR4xbou/QJvqJlvzlYCLdrYbfXUyoLwdFJ90eNESfIHu8OfxGpzeKi8ceSEG6hieoEMnCp/wFnOogdGpz93pR1msU=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5996), "imdad@123" });
        }
    }
}
