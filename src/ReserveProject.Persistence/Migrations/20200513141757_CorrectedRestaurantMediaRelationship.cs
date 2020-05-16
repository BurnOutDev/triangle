using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class CorrectedRestaurantMediaRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationCustomer");

            migrationBuilder.DropTable(
                name: "RestaurantMedia");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "MenuItem");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                table: "Promo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Promo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivationDate",
                table: "Promo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Unavailable",
                table: "MenuItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Format",
                table: "Media",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Media",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Restaurant_RestaurantId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_RestaurantId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                table: "Promo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Promo");

            migrationBuilder.DropColumn(
                name: "DeactivationDate",
                table: "Promo");

            migrationBuilder.DropColumn(
                name: "Unavailable",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "Available",
                table: "MenuItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Format",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "ReservationCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EntityStatus = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationCustomer_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityStatus = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMedia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCustomer_CustomerId",
                table: "ReservationCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCustomer_ReservationId",
                table: "ReservationCustomer",
                column: "ReservationId");
        }
    }
}
