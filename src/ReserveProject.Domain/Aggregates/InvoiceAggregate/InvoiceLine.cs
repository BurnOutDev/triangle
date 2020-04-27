using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceLine : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual List<InvoiceLineTax> InvoiceLineTaxes { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmmount { get; set; }

        public InvoiceLine()
        {
        }

        public static InvoiceLine Create(Product product, string description, int quantity, decimal price)
        {
            var line = new InvoiceLine()
            {
                Product = product,
                Description = description,
                Quantity = quantity,
                Price = price,
                SubTotal = price * quantity
            };

            line.InvoiceLineTaxes = line.Product.ProductTaxes.Select(x => new InvoiceLineTax() { InvoiceLine = line, Tax = x.Tax }).ToList();

            line.CalculateTaxAmmount();

            return line;
        }

        public void Update(int productId, string description, int quantity, decimal price)
        {
            ProductId = productId;
            Description = description;
            Quantity = quantity;
            Price = price;
            SubTotal = Price * Quantity;
            CalculateTaxAmmount();
        }

        public override void Delete()
        {
            base.Delete();
        }

        private void CalculateTaxAmmount()
        {
            var taxes = InvoiceLineTaxes.Select(x => x.Tax);

            foreach (var tax in taxes)
                TaxAmmount += tax.Computation == TaxComputation.Fixed ? tax.Value : SubTotal * tax.Value / 100;
        }
    }

    public class InvoiceLineTax
    {
        public int InvoiceLineId { get; set; }
        public virtual InvoiceLine InvoiceLine { get; set; }
        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
