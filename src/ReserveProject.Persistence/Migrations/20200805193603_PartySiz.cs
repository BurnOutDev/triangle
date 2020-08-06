using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class PartySiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartySize",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "PartySizeAdults",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartySizeChildren",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartySizeAdults",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PartySizeChildren",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "PartySize",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
