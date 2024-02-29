using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0336ec23-5be0-4ca0-b34e-9f7e80e1bc3c", null, "Admin", null },
                    { "71ec1009-7d33-491c-8cb1-488afe5cc502", null, "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0336ec23-5be0-4ca0-b34e-9f7e80e1bc3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ec1009-7d33-491c-8cb1-488afe5cc502");
        }
    }
}
