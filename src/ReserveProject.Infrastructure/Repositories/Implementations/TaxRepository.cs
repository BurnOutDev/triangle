using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class TaxRepository : EfRepository<Tax>, ITaxRepository
    {
        public TaxRepository(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
