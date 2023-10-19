using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNotes.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTabToSheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TabId",
                table: "Sheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_TabId",
                table: "Sheets",
                column: "TabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Tabs_TabId",
                table: "Sheets",
                column: "TabId",
                principalTable: "Tabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Tabs_TabId",
                table: "Sheets");

            migrationBuilder.DropTable(
                name: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_TabId",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "TabId",
                table: "Sheets");
        }
    }
}
