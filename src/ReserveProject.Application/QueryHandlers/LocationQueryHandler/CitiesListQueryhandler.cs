using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Database.Extensions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.LocationQueries;
using static ReserveProject.Application.Queries.LocationQueries.CitiesListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class CitiesListQueryhandler : QueryHandler<CitiesListQuery, CitiesListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public CitiesListQueryhandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public override async Task<QueryExecutionResult<CitiesListQueryResult>> Handle(CitiesListQuery request, CancellationToken cancellationToken)
        {
            var cities = _invoicingDbContext.Set<City>().GetActiveEntities().Select(x => new CityResult()
            {
                Name = x.Name,
                UId = x.UId,
                StateUId = x.State.UId,
                CountryUId = x.State.Country.UId,
                State = x.State.Name,
                Country = x.State.Country.Name
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new CitiesListQueryResult()
            {
                Items = cities.Page(request).ToList(),
                ItemsCount = cities.Count()
            });
        }
    }

}