using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.Currency;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.CurrencyAggregate;
using static ReserveProject.Application.Queries.Currency.CurrenciesListQueryResult;
using ReserveProject.Shared.PagingAndFilter;

namespace ReserveProject.Application.QueryHandlers
{
    public class CurrenciesListQueryHandler : QueryHandler<CurrenciesListQuery, CurrenciesListQueryResult>
    {
        private readonly PrimeDbContext _primeDbContext;

        public CurrenciesListQueryHandler(PrimeDbContext primeDbContext) : base(primeDbContext)
        {
            _primeDbContext = primeDbContext;
        }

        public override async Task<QueryExecutionResult<CurrenciesListQueryResult>> Handle(CurrenciesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CurrencyResult> currencies = _primeDbContext.Set<Currency>()/*.GetActiveEntities()*/.Select(x => new CurrencyResult()
            {
                UId = x.UId,
                Name = x.Name,
                Code = x.Code,
                Symbol = x.Symbol
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new CurrenciesListQueryResult()
            {
                Items = currencies.Page(request).ToList(),
                ItemsCount = currencies.Count()
            });
        }
    }
}
