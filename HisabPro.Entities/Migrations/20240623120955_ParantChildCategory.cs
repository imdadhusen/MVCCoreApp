using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HisabPro.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ParantChildCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9984), null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9987), null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9988), null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9990), null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9992), null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9994), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(26), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(28), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(30), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(31), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(33), null, null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(35), null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9620), null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9625), null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9628), null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9631), null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 23, 12, 9, 55, 309, DateTimeKind.Utc).AddTicks(9633), null, null });

            migrationBuilder.InsertData(
                table: "ParentCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(67), true, false, null, null, "House Hold Items" },
                    { 2, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(69), true, false, null, null, "Offline Shopping" },
                    { 3, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(71), true, false, null, null, "Online Shopping" },
                    { 4, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(73), true, false, null, null, "Bills" },
                    { 5, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(75), true, false, null, null, "Insurance" },
                    { 6, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(77), true, false, null, null, "Education" },
                    { 7, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(78), true, false, null, null, "Vehical Service" },
                    { 8, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(80), true, false, null, null, "Fuel" },
                    { 9, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(82), true, false, null, null, "Donation" },
                    { 10, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(83), true, false, null, null, "Food" },
                    { 11, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(85), true, false, null, null, "Doctor" },
                    { 12, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(87), true, false, null, null, "Personal Care" },
                    { 13, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(88), true, false, null, null, "Recharge" },
                    { 14, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(90), true, false, null, null, "Tour (Picnic)" },
                    { 15, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(92), true, false, null, null, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "ChildCategories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(131), true, false, null, null, "Mobile", 12 },
                    { 2, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(133), true, false, null, null, "Watch", 12 },
                    { 3, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(225), true, false, null, null, "Electric", 1 },
                    { 4, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(227), true, false, null, null, "Maintenance", 4 },
                    { 5, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(228), true, false, null, null, "Property Tax", 4 },
                    { 6, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(231), true, false, null, null, "Kitchen", 3 },
                    { 7, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(233), true, false, null, null, "Bathroom", 12 },
                    { 8, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(234), true, false, null, null, "Rooms", 1 },
                    { 9, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(236), true, false, null, null, "Bread", 10 },
                    { 10, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(238), true, false, null, null, "Milk", 10 },
                    { 11, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(239), true, false, null, null, "Buttermilk", 10 },
                    { 12, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(241), true, false, null, null, "Curd", 10 },
                    { 13, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(242), true, false, null, null, "Juice", 10 },
                    { 14, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(244), true, false, null, null, "Coldrink", 10 },
                    { 15, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(246), true, false, null, null, "Icecreame", 10 },
                    { 16, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(247), true, false, null, null, "Egg", 10 },
                    { 17, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(249), true, false, null, null, "Pulses (Kathol)", 10 },
                    { 18, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(251), true, false, null, null, "Dalaman", 10 },
                    { 19, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(252), true, false, null, null, "Lunch", 10 },
                    { 20, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(254), true, false, null, null, "Dinner", 10 },
                    { 21, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(255), true, false, null, null, "Parcel", 10 },
                    { 22, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(257), true, false, null, null, "Nasto", 10 },
                    { 23, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(259), true, false, null, null, "Vegitables", 10 },
                    { 24, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(260), true, false, null, null, "Masala", 10 },
                    { 25, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(262), true, false, null, null, "Fruits", 10 },
                    { 26, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(263), true, false, null, null, "Fish", 10 },
                    { 27, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(265), true, false, null, null, "Mango", 10 },
                    { 28, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(266), true, false, null, null, "Sweets", 10 },
                    { 29, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(268), true, false, null, null, "Chicken", 10 },
                    { 30, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(270), true, false, null, null, "Oil", 10 },
                    { 31, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(271), true, false, null, null, "Bakery Items", 10 },
                    { 32, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(273), true, false, null, null, "Mutton", 10 },
                    { 33, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(274), true, false, null, null, "Dr Visit (Appointment)", 11 },
                    { 34, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(276), true, false, null, null, "Reports", 11 },
                    { 35, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(278), true, false, null, null, "Toothpaste", 11 },
                    { 36, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(279), true, false, null, null, "Medicine", 11 },
                    { 37, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(281), true, false, null, null, "Sadaka", 9 },
                    { 38, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(282), true, false, null, null, "Saiyad Saheb", 9 },
                    { 39, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(284), true, false, null, null, "Donation", 9 },
                    { 40, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(286), true, false, null, null, "Molvi Saheb", 9 },
                    { 41, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(287), true, false, null, null, "Mujawar", 9 },
                    { 42, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(289), true, false, null, null, "Dargah", 9 },
                    { 43, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(290), true, false, null, null, "Nyaz", 9 },
                    { 44, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(292), true, false, null, null, "Help", 9 },
                    { 45, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(294), true, false, null, null, "Imam Bargah", 9 },
                    { 46, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(295), true, false, null, null, "Masjid", 9 },
                    { 47, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(297), true, false, null, null, "Zakat & Khums", 9 },
                    { 48, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(298), true, false, null, null, "Watchman", 9 },
                    { 49, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(300), true, false, null, null, "Personal Expense", 15 },
                    { 50, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(301), true, false, null, null, "Mobile Recharge", 13 },
                    { 51, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(303), true, false, null, null, "Fast Tag", 13 },
                    { 52, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(304), true, false, null, null, "Fees", 6 },
                    { 53, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(306), true, false, null, null, "Tution", 6 },
                    { 54, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(307), true, false, null, null, "Stationary", 6 },
                    { 55, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(309), true, false, null, null, "Text Books", 6 },
                    { 56, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(311), true, false, null, null, "Note Books", 6 },
                    { 57, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(312), true, false, null, null, "School Dress", 6 },
                    { 58, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(315), true, false, null, null, "Hotel", 14 },
                    { 59, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(316), true, false, null, null, "Picnic", 14 },
                    { 60, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(318), true, false, null, null, "Tour", 14 },
                    { 61, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(320), true, false, null, null, "Cloths", 12 },
                    { 62, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(321), true, false, null, null, "Life Insurance", 12 },
                    { 63, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(323), true, false, null, null, "Islamic", 9 },
                    { 64, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(324), true, false, null, null, "Gift", 9 },
                    { 65, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(326), true, false, null, null, "Hair Cut", 12 },
                    { 66, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(327), true, false, null, null, "Transportation", 15 },
                    { 67, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(329), true, false, null, null, "Beauty", 12 },
                    { 68, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(330), true, false, null, null, "Shooe", 12 },
                    { 69, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(332), true, false, null, null, "Diaper", 12 },
                    { 70, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(334), true, false, null, null, "Petrol", 8 },
                    { 71, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(337), true, false, null, null, "GAS", 8 },
                    { 72, 1, new DateTime(2024, 6, 23, 12, 9, 55, 310, DateTimeKind.Utc).AddTicks(339), true, false, null, null, "CAR", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "ParentCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5804), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5807), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5808), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5810), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5812), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5813), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5836), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5838), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5840), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5841), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5843), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5844), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5626), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5629), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5632), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5634), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5635), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
