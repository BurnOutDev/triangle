using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class PartyRepository : EfRepository<Party>, IPartyRepository
    {
        public PartyRepository(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
