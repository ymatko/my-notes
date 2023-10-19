using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSheetToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SheetId",
                table: "Tabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_SheetId",
                table: "Tabs",
                column: "SheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Sheets_SheetId",
                table: "Tabs",
                column: "SheetId",
                principalTable: "Sheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Sheets_SheetId",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_SheetId",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "SheetId",
                table: "Tabs");
        }
    }
}
