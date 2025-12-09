using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LystfiskerPortalen.Migrations
{
    /// <inheritdoc />
    public partial class ChannelsDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "ChannelId", "Name" },
                values: new object[,]
                {
                    { "1", "Nordjylland" },
                    { "2", "Midtjylland" },
                    { "3", "Syddanmark" },
                    { "4", "Sjælland" },
                    { "5", "Hovedstaden" },
                    { "6", "Bornholm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "ChannelId",
                keyValue: "6");
        }
    }
}
