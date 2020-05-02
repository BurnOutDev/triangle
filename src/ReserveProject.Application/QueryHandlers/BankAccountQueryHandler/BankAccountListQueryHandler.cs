using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.BankAccountQueries;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.BankAccountQueries.BankAccountListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class BankAccountListQueryHandler : QueryHandler<BankAccountListQuery, BankAccountListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public BankAccountListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<BankAccountListQueryResult>> Handle(BankAccountListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<BankAccount>().Select(x => new BankAccountResult()
            {
                UId = x.UId,
                Name = x.Name,
                Number = x.Number,
                BankUId = x.Bank.UId,
                Bank = x.Bank.Name
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new BankAccountListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
