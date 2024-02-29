using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class assignrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                          table: "AspNetRoles",
                          columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                          values: new object[] { Guid.NewGuid().ToString(), "User", "user".ToUpper(), Guid.NewGuid().ToString() }
                         
              );
            migrationBuilder.InsertData(
                            table: "AspNetRoles",
                            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                            values: new object[] { Guid.NewGuid().ToString(), "Admin", "admin".ToUpper(), Guid.NewGuid().ToString() }
                            
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete * from dbo.AspNetRoles");
        }
    }
}
