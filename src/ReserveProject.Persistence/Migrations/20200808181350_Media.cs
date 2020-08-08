using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Persistence.Migrations
{
    public partial class Media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Stars",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ReviewMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityStatus = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: true),
                    MediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewMedia_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewMedia_MediaId",
                table: "ReviewMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewMedia_ReviewId",
                table: "ReviewMedia",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewMedia");

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
