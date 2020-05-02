using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.PaymentTermQueries;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.PaymentTermQueries.PaymentTermListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class PaymentTermListQueryHandler : QueryHandler<PaymentTermListQuery, PaymentTermListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public PaymentTermListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<PaymentTermListQueryResult>> Handle(PaymentTermListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<PaymentTerm>().Select(x => new PaymentTermResult()
            {
                UId = x.UId,
                Name = x.Name,
                Description = x.Description,
                DaysCount = x.DaysCount
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new PaymentTermListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
