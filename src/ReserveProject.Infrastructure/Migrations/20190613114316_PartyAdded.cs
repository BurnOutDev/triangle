using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Infrastructure.Migrations
{
    public partial class PartyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "BankAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityStatus = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    StreetDetails = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    TaxCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Language = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Party_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_PartyId",
                table: "BankAccount",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_CityId",
                table: "Party",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Party_PartyId",
                table: "BankAccount",
                column: "PartyId",
                principalTable: "Party",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Party_PartyId",
                table: "BankAccount");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_PartyId",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "BankAccount");
        }
    }
}
