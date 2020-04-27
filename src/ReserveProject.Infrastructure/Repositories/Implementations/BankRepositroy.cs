using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class BankRepositroy : EfRepository<Bank>, IBankRepository
    {
        public BankRepositroy(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
