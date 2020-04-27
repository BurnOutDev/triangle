using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReserveProject.Infrastructure.Migrations
{
    public partial class InvoiceInvoiceLineAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityStatus = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UId = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    PaymentTermId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    DueDate = table.Column<DateTimeOffset>(nullable: false),
                    SalesPersonId = table.Column<int>(nullable: false),
                    UnTaxedAmount = table.Column<decimal>(nullable: false),
                    TaxAmmount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentTerm_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalTable: "PaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_SalesPerson_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityStatus = table.Column<int>(nullable: false),
                    LastChangeDate = table.Column<DateTimeOffset>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TaxAmmount = table.Column<decimal>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineTax",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(nullable: false),
                    TaxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineTax", x => new { x.InvoiceLineId, x.TaxId });
                    table.ForeignKey(
                        name: "FK_InvoiceLineTax_InvoiceLine_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "InvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLineTax_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentTermId",
                table: "Invoice",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SalesPersonId",
                table: "Invoice",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_ProductId",
                table: "InvoiceLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineTax_TaxId",
                table: "InvoiceLineTax",
                column: "TaxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLineTax");

            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
