using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Location;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Database.Extensions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.LocationQueries;
using static ReserveProject.Application.Queries.LocationQueries.LocationListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class LocationListQueryhandler : QueryHandler<LocationListQuery, LocationListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public LocationListQueryhandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<LocationListQueryResult>> Handle(LocationListQuery request, CancellationToken cancellationToken)
        {
            var locations = _invoicingDbContext.Set<City>().GetActiveEntities()
                                                         .Select(x => new LocationListResult()
                                                         {
                                                             Location = x.State.Country.Name + ", " + x.State.Name + ", " + x.Name,
                                                             City = x.Name,
                                                             CityUId = x.UId,
                                                             State = x.State.Name,
                                                             Country = x.State.Country.Name
                                                         }).Filter(request.FilterModel).Sort(request.SortModel);

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                locations = locations.Where(x => x.Country.Contains(request.SearchText) || x.State.Contains(request.SearchText) || x.City.Contains(request.SearchText));
            }

            return await Ok(new LocationListQueryResult()
            {
                Items = locations.Page(request).ToList(),
                ItemsCount = locations.Count()
            });
        }
    }

}