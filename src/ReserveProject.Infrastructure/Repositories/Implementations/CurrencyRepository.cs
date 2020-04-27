using ReserveProject.Domain.Aggregates.CurrencyAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class CurrencyRepository : EfRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(PrimeDbContext primeDbContext) : base(primeDbContext)
        {
        }
    }
}
