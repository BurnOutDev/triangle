using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Infrastructure.Migrations
{
    public partial class addEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Event");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    EntityId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    RemoteIp = table.Column<string>(nullable: true),
                    ProcessedByJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "Event");
        }
    }
}
