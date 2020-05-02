using ReserveProject.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.DTOs.Invoice
{
    public class InvoiceLineDTO
    {
        public Product Product{ get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
