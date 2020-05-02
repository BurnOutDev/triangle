using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Infrastructure.Database.Extensions;
using ReserveProject.Application.Queries.LocationQueries;
using static ReserveProject.Application.Queries.LocationQueries.StatesListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class StatesListQueryhandler : QueryHandler<StatesListQuery, StatesListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public StatesListQueryhandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public override async Task<QueryExecutionResult<StatesListQueryResult>> Handle(StatesListQuery request, CancellationToken cancellationToken)
        {
            var states = _invoicingDbContext.Set<State>().GetActiveEntities().Select(x => new StateResult()
            {
                UId = x.UId,
                Country = x.Country.Name,
                Name = x.Name
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new StatesListQueryResult()
            {
                Items = states.Page(request).ToList(),
                ItemsCount = states.Count()
            });

        }
    }
}