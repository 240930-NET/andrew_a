using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.API.Migrations
{
    /// <inheritdoc />
    public partial class TestSingleton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Singleton",
                table: "Bestiary",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Blurb", "Singleton" },
                values: new object[] { "A giant arthopod covered in heavy scales and venomous barbs.", false });

            migrationBuilder.UpdateData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 2,
                column: "Singleton",
                value: false);

            migrationBuilder.InsertData(
                table: "Bestiary",
                columns: new[] { "ID", "Blurb", "Height", "Name", "Singleton", "Weight" },
                values: new object[] { 3, "This mummified priest commands swarms of locusts to gather food and treasure to his tomb.", 1.0, "Locustus", true, 20.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Singleton",
                table: "Bestiary");

            migrationBuilder.UpdateData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 1,
                column: "Blurb",
                value: "A giant scorpion covered in heavy scales and venomous barbs.");
        }
    }
}
