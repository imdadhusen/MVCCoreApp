using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Entities.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4868), 5 });

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4879), 16 });

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4880), 16 });

            migrationBuilder.InsertData(
                table: "ChildCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { 75, 1, new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4881), true, false, null, null, "Mall", 2 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 28, 8, 50, 32, 18, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories");

            migrationBuilder.DeleteData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3894), 12 });

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3968), 8 });

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedOn", "ParentCategoryId" },
                values: new object[] { new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3969), 7 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3297));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 13, 59, 15, 28, DateTimeKind.Utc).AddTicks(3573));

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
