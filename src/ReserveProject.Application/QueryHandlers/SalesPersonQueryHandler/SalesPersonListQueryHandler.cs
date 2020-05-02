using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.SalesPersonQueries;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.SalesPersonQueries.SalesPersonListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class SalesPersonListQueryHandler : QueryHandler<SalesPersonListQuery, SalesPersonListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public SalesPersonListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<SalesPersonListQueryResult>> Handle(SalesPersonListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<SalesPerson>().Select(x => new SalesPersonResult()
            {
                UId = x.UId,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Mobile = x.Mobile
            }).Filter(request.FilterModel).Sort(request.SortModel);
            return await Ok(new SalesPersonListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
