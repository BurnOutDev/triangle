using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Location;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.QueryHandlers
{
    public class StateDetailsQueryHandler : QueryHandler<StateDetailsQuery, StateDetailsQueryResult>
    {

        public StateDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<StateDetailsQueryResult>> Handle(StateDetailsQuery request, CancellationToken cancellationToken)
        {
            State state = Entity<State>(request.UId);

            return await Ok(new StateDetailsQueryResult()
            {
                UId = state.UId,
                Name = state.Name,
                Country = state.Country.Name,
                CountryUId = state.Country.UId
            });
        }
    }
}
