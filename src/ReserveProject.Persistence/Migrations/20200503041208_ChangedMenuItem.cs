using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class ChangedMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "MenuItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItem",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Restaurant_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Restaurant_RestaurantId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "MenuItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "MenuItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
