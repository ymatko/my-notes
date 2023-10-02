using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdToSheetV20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sheets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_ApplicationUserId",
                table: "Sheets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_AspNetUsers_ApplicationUserId",
                table: "Sheets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_AspNetUsers_ApplicationUserId",
                table: "Sheets");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_ApplicationUserId",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sheets");
        }
    }
}
