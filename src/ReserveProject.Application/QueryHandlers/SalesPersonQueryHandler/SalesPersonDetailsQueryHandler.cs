using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.SalesPersonQueries;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class SalesPersonDetailsQueryHandler : QueryHandler<SalesPersonDetailsQuery, SalesPersonDetailsQueryResult>
    {
        public SalesPersonDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<SalesPersonDetailsQueryResult>> Handle(SalesPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<SalesPerson>(request.UId);

            return await Ok(new SalesPersonDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                Email = result.Email,
                Phone = result.Phone,
                Mobile = result.Mobile
            });
        }
    }

}
