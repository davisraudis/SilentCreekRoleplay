using Microsoft.EntityFrameworkCore.Migrations;

namespace SilentCreekRoleplay.DataLayer.Migrations
{
    public partial class PlayerAttributesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "A",
                table: "Players",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Health",
                table: "Players",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Skin",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Skin",
                table: "Players");
        }
    }
}
