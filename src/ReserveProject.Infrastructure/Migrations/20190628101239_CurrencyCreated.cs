using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Infrastructure.Migrations
{
    public partial class CurrencyCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityStatus = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 3, nullable: true),
                    Symbol = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
