using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.InvoiceQueries
{
    public class InvoiceDetailsQuery : IQuery<QueryExecutionResult<InvoiceDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class InvoiceDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string InvoiceNumber { get; set; }
        public InvoiceStatus Status { get; set; }
        public Guid CustomerUId { get; set; }
        public string Customer { get; set; }
        public Guid PaymentTermUId { get; set; }
        public string PaymentTerm { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public Guid SalesPersonUId { get; set; }
        public string SalesPerson { get; set; }
        public decimal UnTaxedAmount { get; set; }
        public decimal TaxAmmount { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceLineResult> InvoiceLines { get; set; }

        public class InvoiceLineResult
        {
            public Guid ProductUId { get; set; }
            public string Product { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal SubTotal { get; set; }
            public IEnumerable<TaxResult> Taxes { get; set; }

            public class TaxResult
            {
                public Guid TaxUId { get; set; }
                public string Tax { get; set; }
            }

        }
    }
}
