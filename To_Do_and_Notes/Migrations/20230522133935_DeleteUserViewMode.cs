using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_and_Notes.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserViewMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewMode",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewMode",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
