using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.BankAccountQueries;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class BankAccountDetailsQueryHandler : QueryHandler<BankAccountDetailsQuery, BankAccountDetailsQueryResult>
    {
        public BankAccountDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<BankAccountDetailsQueryResult>> Handle(BankAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<BankAccount>(request.UId);

            return await Ok(new BankAccountDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                Number = result.Number,
                BankUId = result.Bank.UId,
                Bank = result.Bank.Name
            });
        }
    }

}
