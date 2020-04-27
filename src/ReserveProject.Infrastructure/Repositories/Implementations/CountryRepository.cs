using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class CountryRepository : EfRepository<Country>, ICountryRepository
    {
        private readonly PrimeDbContext _dbContext;

        public CountryRepository(PrimeDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
