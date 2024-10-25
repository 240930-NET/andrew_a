using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.API.Migrations
{
    /// <inheritdoc />
    public partial class P1Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Height", "Weight" },
                values: new object[] { 6.0, 80.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Height", "Weight" },
                values: new object[] { 1.0, 20.0 });
        }
    }
}
