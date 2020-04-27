
using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.PartyQueries;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.PartyQueries.PartyListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class PartyListQueryHandler : QueryHandler<PartyListQuery, PartyListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public PartyListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<PartyListQueryResult>> Handle(PartyListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Party>().Select(x => new PartyResult()
            {
                UId = x.UId,
                Name = x.Name,
                Role = x.Role,
                Type = x.Type,
                TaxCode = x.TaxCode,
                Email = x.Email,
                CityUId = x.City.UId,
                City = x.City.Name,
                Street = x.Street,
                StreetDetails = x.StreetDetails,
                Language = x.Language,
                Mobile = x.Mobile,
                Phone = x.Phone,
                BankAccounts = x.BankAccounts.Select(x => new PartyResult.BankAccountResult() { UId = x.UId, Name = x.Name })
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new PartyListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
