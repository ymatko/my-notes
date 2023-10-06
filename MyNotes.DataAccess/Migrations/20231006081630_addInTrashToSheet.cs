using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addInTrashToSheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InTrash",
                table: "Sheets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTrash",
                table: "Sheets");
        }
    }
}
