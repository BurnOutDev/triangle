using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class CityRepository : EfRepository<City>, ICityRepository
    {
        private readonly PrimeDbContext _dbContext;

        public CityRepository(PrimeDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
