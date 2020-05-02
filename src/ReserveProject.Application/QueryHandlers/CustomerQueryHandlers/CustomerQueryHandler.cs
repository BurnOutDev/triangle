using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Application.Queries.CustomerQueries;
using static ReserveProject.Application.Queries.CustomerQueries.CustomerListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{

    public class CustomerListQueryHandler : QueryHandler<CustomerListQuery, CustomerListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public CustomerListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<CustomerListQueryResult>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Customer>().Select(x => new CustomerResult()
            {
                UId = x.UId,
                Name = x.Name,
            }).Filter(request.FilterModel).Sort(request.SortModel);
            return await Ok(new CustomerListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }
}
