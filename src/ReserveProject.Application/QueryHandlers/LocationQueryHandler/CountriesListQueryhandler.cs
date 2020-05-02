using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Infrastructure.Database.Extensions;
using ReserveProject.Application.Queries.LocationQueries;
using static ReserveProject.Application.Queries.LocationQueries.CountriesListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class CountriesListQueryhandler : QueryHandler<CountriesListQuery, CountriesListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public CountriesListQueryhandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public override async Task<QueryExecutionResult<CountriesListQueryResult>> Handle(CountriesListQuery request, CancellationToken cancellationToken)
        {
            var countries = _invoicingDbContext.Set<Country>().GetActiveEntities().Select(x => new CountryResult()
            {
                CountryCode = x.CountryCode,
                Name = x.Name,
                UId = x.UId
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new CountriesListQueryResult()
            {
                Items = countries.Page(request).ToList(),
                ItemsCount = countries.Count()
            });
        }
    }


}