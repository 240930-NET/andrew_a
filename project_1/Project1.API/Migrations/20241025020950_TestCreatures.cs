using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1.API.Migrations
{
    /// <inheritdoc />
    public partial class TestCreatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Blurb",
                table: "Bestiary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Bestiary",
                columns: new[] { "ID", "Blurb", "Height", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "A giant scorpion covered in heavy scales and venomous barbs.", 3.0, "Giant Scorpion", 70.0 },
                    { 2, "A carnivorous spherical cactus who catches small insects by rolling over them.", 1.0, "Cactorb", 20.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bestiary",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Blurb",
                table: "Bestiary");
        }
    }
}
