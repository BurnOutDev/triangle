using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.PartyQueries;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class PartyDetailsQueryHandler : QueryHandler<PartyDetailsQuery, PartyDetailsQueryResult>
    {
        public PartyDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<PartyDetailsQueryResult>> Handle(PartyDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<Party>(request.UId);

            return await Ok(new PartyDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                Role = result.Role,
                Type = result.Type,
                Email = result.Email,
                Mobile = result.Mobile,
                Phone = result.Phone,
                Street = result.Street,
                Language = result.Language,
                StreetDetails = result.StreetDetails,
                TaxCode = result.TaxCode,
                CityUId = result.City.UId,
                City = result.City.Name,
                BankAccounts = result.BankAccounts.Select(x => new PartyDetailsQueryResult.BankAccountResult() { UId = x.UId, Name = x.Name })
            });
        }
    }

}
