using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0336ec23-5be0-4ca0-b34e-9f7e80e1bc3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ec1009-7d33-491c-8cb1-488afe5cc502");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f0c0fa7-e343-43ec-9745-b6cce43acb85", "e9ab0374-60f5-45e6-b3ab-7c03f6dc298f", "User", "USER" },
                    { "db24461c-fc5a-4554-ad53-c2e202f76859", "cf520f29-7b25-4fb3-9de5-ac3b3fed3761", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0c0fa7-e343-43ec-9745-b6cce43acb85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db24461c-fc5a-4554-ad53-c2e202f76859");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0336ec23-5be0-4ca0-b34e-9f7e80e1bc3c", null, "Admin", null },
                    { "71ec1009-7d33-491c-8cb1-488afe5cc502", null, "User", null }
                });
        }
    }
}
