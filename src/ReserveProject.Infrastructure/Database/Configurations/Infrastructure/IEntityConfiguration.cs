using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Database.Configurations.Infrastructure
{
    public interface IEntityConfiguration
    {
        void Map(ModelBuilder builder);
    }
}