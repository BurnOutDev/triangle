using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Location;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.QueryHandlers
{
    public class CountryDetailsQueryHandler : QueryHandler<CountryDetailsQuery, CountryDetailsQueryResult>
    {

        public CountryDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<CountryDetailsQueryResult>> Handle(CountryDetailsQuery request, CancellationToken cancellationToken)
        {
            Country country = Entity<Country>(request.UId);

            return await Ok(new CountryDetailsQueryResult()
            {
                UId = country.UId,
                Name = country.Name,
                CountryCode = country.CountryCode
            });
        }
    }
}
