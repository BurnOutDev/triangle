using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.PaymentTermQueries;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class PaymentTermDetailsQueryHandler : QueryHandler<PaymentTermDetailsQuery, PaymentTermDetailsQueryResult>
    {
        public PaymentTermDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<PaymentTermDetailsQueryResult>> Handle(PaymentTermDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<PaymentTerm>(request.UId);

            return await Ok(new PaymentTermDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                Description = result.Description,
                DaysCount = result.DaysCount
            });
        }
    }

}
