using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.BankQueries;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class BankDetailsQueryHandler : QueryHandler<BankDetailsQuery, BankDetailsQueryResult>
    {
        private readonly PrimeDbContext invoicingDbContext;

        public BankDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<BankDetailsQueryResult>> Handle(BankDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<Bank>(request.UId);

            return await Ok(new BankDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                CityUId = result.City.UId,
                Email = result.Email,
                IdentifierCode = result.IdentifierCode,
                IsActive = result.IsActive,
                Location = string.Format("{0}, {1}, {2}", result.City.State.Country.Name, result.City.State.Name, result.City.Name),
                Phone = result.Phone,
                Street = result.Street,
                StreetInDetails = result.StreetInDetails,
                ZipCode = result.ZipCode
            });
        }
    }

}
