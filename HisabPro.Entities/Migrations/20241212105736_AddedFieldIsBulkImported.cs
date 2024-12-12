using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HisabPro.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldIsBulkImported : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBulkImported",
                table: "Incomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBulkImported",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBulkImported",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "IsBulkImported",
                table: "Expenses");
        }
    }
}
