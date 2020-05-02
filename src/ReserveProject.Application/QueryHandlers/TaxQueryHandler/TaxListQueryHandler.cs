using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.TaxQueries;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.TaxQueries.TaxListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class TaxListQueryHandler : QueryHandler<TaxListQuery, TaxListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public TaxListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<TaxListQueryResult>> Handle(TaxListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Tax>().Select(x => new TaxResult()
            {
                UId = x.UId,
                Name = x.Name,
                Scope = x.Scope,
                Computation = x.Computation,
                Value = x.Value
            }).Filter(request.FilterModel).Sort(request.SortModel);
            return await Ok(new TaxListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
