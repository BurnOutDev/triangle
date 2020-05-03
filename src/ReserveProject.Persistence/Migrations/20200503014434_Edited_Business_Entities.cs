using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class Edited_Business_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Location_LocationId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Organization_OrganizationId",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_LocationId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_OrganizationId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "BusinessId",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookId",
                table: "Restaurant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "FacebookId",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityStatus = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityStatus = table.Column<int>(type: "int", nullable: false),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentativeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Customer_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_LocationId",
                table: "Restaurant",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_OrganizationId",
                table: "Restaurant",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_RepresentativeId",
                table: "Organization",
                column: "RepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Location_LocationId",
                table: "Restaurant",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Organization_OrganizationId",
                table: "Restaurant",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
