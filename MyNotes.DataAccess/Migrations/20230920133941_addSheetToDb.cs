using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSheetToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sheets",
                columns: new[] { "Id", "Name", "Text" },
                values: new object[,]
                {
                    { 1, "1", "One" },
                    { 2, "2", "Two" },
                    { 3, "3", "Three" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sheets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sheets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sheets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
