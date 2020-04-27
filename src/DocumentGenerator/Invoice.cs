using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentGenerator
{
    public class Invoice
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public string Term { get; set; }


        public string SellerName { get; set; }
        public string SellerCountry { get; set; }
        public string SellerEmail { get; set; }


        public string BuyerName { get; set; }
        public string BuyerCountry { get; set; }
        public string BuyerEmail { get; set; }



        public IEnumerable<Product> Products { get; set; }

        public decimal SubTotal { get; set; }
        public int Fee { get; set; }

        public string Currency { get; set; }
        public decimal Total
        {
            get
            {
                return Products.Sum(x => x.Amount);
            }
            set { }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Descpription { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

    }
}
