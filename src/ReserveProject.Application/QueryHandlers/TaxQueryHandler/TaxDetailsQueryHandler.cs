using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.TaxQueries;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class TaxDetailsQueryHandler : QueryHandler<TaxDetailsQuery, TaxDetailsQueryResult>
    {
        public TaxDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<TaxDetailsQueryResult>> Handle(TaxDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<Tax>(request.UId);

            return await Ok(new TaxDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                Scope = result.Scope,
                Computation = result.Computation,
                Value = result.Value
            });
        }
    }

}
