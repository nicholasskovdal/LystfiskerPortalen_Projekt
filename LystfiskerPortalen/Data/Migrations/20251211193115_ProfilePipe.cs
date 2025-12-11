using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystfiskerPortalen.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AspNetUsers",
                newName: "ProfileName");

            migrationBuilder.CreateTable(
                name: "ProfileProfile",
                columns: table => new
                {
                    FollowersProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowingProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfile", x => new { x.FollowersProfileId, x.FollowingProfileId });
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowersProfileId",
                        column: x => x.FollowersProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowingProfileId",
                        column: x => x.FollowingProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_FollowingProfileId",
                table: "ProfileProfile",
                column: "FollowingProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileProfile");

            migrationBuilder.RenameColumn(
                name: "ProfileName",
                table: "AspNetUsers",
                newName: "AppUserId");
        }
    }
}
