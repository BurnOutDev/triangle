using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class Restaurantmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Restaurant_RestaurantId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_RestaurantId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Media");

            migrationBuilder.CreateTable(
                name: "RestaurantMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityStatus = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true),
                    MediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantMedia_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantMedia_MediaId",
                table: "RestaurantMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantMedia_RestaurantId",
                table: "RestaurantMedia",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantMedia");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_RestaurantId",
                table: "Media",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Restaurant_RestaurantId",
                table: "Media",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
