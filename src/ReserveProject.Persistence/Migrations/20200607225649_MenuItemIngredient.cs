using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class MenuItemIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Ingredient_IngredientId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_IngredientId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "CuisineId",
                table: "Restaurant",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MenuItemIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityStatus = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItemIngredient_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_IngredientId",
                table: "MenuItemIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_MenuItemId",
                table: "MenuItemIngredient",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "MenuItemIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "CuisineId",
                table: "Restaurant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "MenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_IngredientId",
                table: "MenuItem",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Ingredient_IngredientId",
                table: "MenuItem",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
