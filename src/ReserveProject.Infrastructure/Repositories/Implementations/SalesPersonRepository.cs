using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class SalesPersonRepository : EfRepository<SalesPerson>, ISalesPersonRepository
    {
        public SalesPersonRepository(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
