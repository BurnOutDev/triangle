using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.InvoiceQueries;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.InvoiceQueries.InvoiceListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class InvoiceListQueryHandler : QueryHandler<InvoiceListQuery, InvoiceListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public InvoiceListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<InvoiceListQueryResult>> Handle(InvoiceListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Invoice>().Select(x => new InvoiceResult()
            {
                UId = x.UId,
                CustomerUId = x.Customer.UId,
                Customer = x.Customer.Name,
                DueDate = x.DueDate,
                InvoiceNumber = x.InvoiceNumber,
                PaymentTermUId = x.PaymentTerm.UId,
                PaymentTerm = x.PaymentTerm.Name,
                SalesPersonUId = x.SalesPerson.UId,
                SalesPerson = x.SalesPerson.Name,
                StartDate = x.StartDate,
                Status = x.Status,
                TaxAmmount = x.TaxAmmount,
                UnTaxedAmount = x.UnTaxedAmount,
                Total = x.Total
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new InvoiceListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
