using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class EditedRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLatitude",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLongtitude",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Restaurant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "AddressLatitude",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "AddressLongtitude",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Restaurant");
        }
    }
}
