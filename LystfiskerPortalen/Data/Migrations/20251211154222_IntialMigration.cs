using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystfiskerPortalen.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AspNetUsers",
                newName: "ProfileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileName",
                table: "AspNetUsers",
                newName: "AppUserId");
        }
    }
}
