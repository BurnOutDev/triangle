using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.InvoiceQueries;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.InvoiceQueries.InvoiceDetailsQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class InvoiceDetailsQueryHandler : QueryHandler<InvoiceDetailsQuery, InvoiceDetailsQueryResult>
    {
        public InvoiceDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<InvoiceDetailsQueryResult>> Handle(InvoiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var invoice = Entity<Invoice>(request.UId);

            var result = new InvoiceDetailsQueryResult()
            {
                UId = invoice.UId,
                CustomerUId = invoice.Customer.UId,
                Customer = invoice.Customer.Name,
                DueDate = invoice.DueDate,
                InvoiceNumber = invoice.InvoiceNumber,
                PaymentTermUId = invoice.PaymentTerm.UId,
                PaymentTerm = invoice.PaymentTerm.Name,
                SalesPersonUId = invoice.SalesPerson.UId,
                SalesPerson = invoice.SalesPerson.Name,
                StartDate = invoice.StartDate,
                Status = invoice.Status,
                TaxAmmount = invoice.TaxAmmount,
                UnTaxedAmount = invoice.UnTaxedAmount,
                Total = invoice.Total,
            };
            result.InvoiceLines = new List<InvoiceLineResult>();

            foreach (var line in invoice.InvoiceLines)
            {
                var resultLine = new InvoiceLineResult()
                {
                    Description = line.Description,
                    Price = line.Price,
                    ProductUId = line.Product.UId,
                    Product = line.Product.Name,
                    SubTotal = line.SubTotal,
                    Quantity = line.Quantity,
                    Taxes = line.InvoiceLineTaxes.Select(x => new InvoiceLineResult.TaxResult()
                    {
                        TaxUId = x.Tax.UId,
                        Tax = x.Tax.Name
                    }).ToList()
                };
                result.InvoiceLines.Add(resultLine);
            }

            return await Ok(result);
        }
    }

}
