using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class StateRepository : EfRepository<State>, IStateRepository
    {
        private readonly PrimeDbContext _dbContext;

        public StateRepository(PrimeDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
