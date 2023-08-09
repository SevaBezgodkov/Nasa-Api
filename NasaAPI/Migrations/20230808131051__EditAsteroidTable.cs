using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaAPI.Migrations
{
    public partial class _EditAsteroidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Asteroids",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Asteroids",
                newName: "EndDate");

            migrationBuilder.AddColumn<string>(
                name: "AsteroidId",
                table: "Asteroids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KilometersToEarth",
                table: "Asteroids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isPotentiallyHazardous",
                table: "Asteroids",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsteroidId",
                table: "Asteroids");

            migrationBuilder.DropColumn(
                name: "KilometersToEarth",
                table: "Asteroids");

            migrationBuilder.DropColumn(
                name: "isPotentiallyHazardous",
                table: "Asteroids");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Asteroids",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Asteroids",
                newName: "endDate");
        }
    }
}
