using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Location;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.QueryHandlers
{
    public class CityDetailsQueryHandler : QueryHandler<CityDetailsQuery, CityDetailsQueryResult>
    {

        public CityDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<CityDetailsQueryResult>> Handle(CityDetailsQuery request, CancellationToken cancellationToken)
        {
            var city = Entity<City>(request.UId);

            return await Ok(new CityDetailsQueryResult()
            {
                UId = city.UId,
                Name = city.Name,
                Country = city.State.Country.Name,
                State = city.State.Name,
                CountryUId = city.State.Country.UId,
                StateUId = city.State.UId
            });
        }
    }
}
