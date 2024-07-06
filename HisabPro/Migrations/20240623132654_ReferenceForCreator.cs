using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceForCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "Password" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 23, 13, 26, 53, 463, DateTimeKind.Utc).AddTicks(5996), "Imdadhusen.sunasara@gmail.com", true, false, null, null, "Imdadhusen", "imdad@123" });

            migrationBuilder.CreateIndex(
                name: "IX_ParentCategories_CreatedBy",
                table: "ParentCategories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ParentCategories_ModifiedBy",
                table: "ParentCategories",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ModifiedBy",
                table: "Employees",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedBy",
                table: "Departments",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_CreatedBy",
                table: "ChildCategories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_ModifiedBy",
                table: "ChildCategories",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreatedBy",
                table: "Addresses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ModifiedBy",
                table: "Addresses",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedBy",
                table: "Users",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_CreatedBy",
                table: "Addresses",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_ModifiedBy",
                table: "Addresses",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_Users_CreatedBy",
                table: "ChildCategories",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_Users_ModifiedBy",
                table: "ChildCategories",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatedBy",
                table: "Departments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ModifiedBy",
                table: "Departments",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_CreatedBy",
                table: "Employees",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_ModifiedBy",
                table: "Employees",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentCategories_Users_CreatedBy",
                table: "ParentCategories",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentCategories_Users_ModifiedBy",
                table: "ParentCategories",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_CreatedBy",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_ModifiedBy",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_Users_CreatedBy",
                table: "ChildCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_Users_ModifiedBy",
                table: "ChildCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatedBy",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ModifiedBy",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_CreatedBy",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_ModifiedBy",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentCategories_Users_CreatedBy",
                table: "ParentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentCategories_Users_ModifiedBy",
                table: "ParentCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ParentCategories_CreatedBy",
                table: "ParentCategories");

            migrationBuilder.DropIndex(
                name: "IX_ParentCategories_ModifiedBy",
                table: "ParentCategories");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ModifiedBy",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ModifiedBy",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategories_CreatedBy",
                table: "ChildCategories");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategories_ModifiedBy",
                table: "ChildCategories");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CreatedBy",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ModifiedBy",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "ChildCategories",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "ParentCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(92));
        }
    }
}
