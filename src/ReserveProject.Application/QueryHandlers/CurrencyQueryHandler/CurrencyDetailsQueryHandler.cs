using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Currency;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.CurrencyAggregate;

namespace ReserveProject.Application.QueryHandlers
{
    public class CurrencyDetailsQueryHandler : QueryHandler<CurrencyDetailsQuery, CurrencyDetailsQueryResult>
    {
        private readonly PrimeDbContext _primeDbContext;

        public CurrencyDetailsQueryHandler(PrimeDbContext primeDbContext) : base(primeDbContext)
        {
            _primeDbContext = primeDbContext;
        }

        public override async Task<QueryExecutionResult<CurrencyDetailsQueryResult>> Handle(CurrencyDetailsQuery request, CancellationToken cancellationToken)
        {
            var currency = RepositoryBase.Entity<Currency>(request.UId);
            
            return await Ok(new CurrencyDetailsQueryResult()
            {
                UId = currency.UId,
                Name = currency.Name,
                Code = currency.Code,
                Symbol = currency.Symbol
            });
        }
    }
}
