using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class BankAccountRepositroy : EfRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepositroy(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
