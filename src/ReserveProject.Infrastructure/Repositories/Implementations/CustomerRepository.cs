using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Domain.Aggregates.CustomerAggregate;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        private readonly PrimeDbContext _dbContext;

        public CustomerRepository(PrimeDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
