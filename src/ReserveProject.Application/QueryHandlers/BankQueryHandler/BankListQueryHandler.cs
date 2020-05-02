using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.BankQueries;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.BankQueries.BankListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class BankListQueryHandler : QueryHandler<BankListQuery, BankListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public BankListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<BankListQueryResult>> Handle(BankListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Bank>().Select(x => new BankResult()
            {
                UId = x.UId,
                Name = x.Name,
                CityUId = x.City.UId,
                Email = x.Email,
                IdentifierCode = x.IdentifierCode,
                IsActive = x.IsActive,
                Location = string.Format("{0}, {1}, {2}", x.City.State.Country.Name, x.City.State.Name, x.City.Name),
                Phone = x.Phone,
                Street = x.Street,
                StreetInDetails = x.StreetInDetails,
                ZipCode = x.ZipCode
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new BankListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
