using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "94a01f9b-b3bc-4113-a31b-e0118e9e8e39", "2c77724d-2138-48c1-893b-4e7a4ff6a3f4", "Admin", "ADMIN" },
                    { "e1f2a723-84de-4b22-89ef-e37c4041a7e9", "a690185f-3c7a-4f2e-bab9-f07aa590c5bc", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a01f9b-b3bc-4113-a31b-e0118e9e8e39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f2a723-84de-4b22-89ef-e37c4041a7e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f0c0fa7-e343-43ec-9745-b6cce43acb85", "e9ab0374-60f5-45e6-b3ab-7c03f6dc298f", "User", "USER" },
                    { "db24461c-fc5a-4554-ad53-c2e202f76859", "cf520f29-7b25-4fb3-9de5-ac3b3fed3761", "Admin", "ADMIN" }
                });
        }
    }
}
