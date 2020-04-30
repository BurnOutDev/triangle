using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Persistence.Configurations.Shared
{
    public interface IEntityConfiguration
    {
        void Map(ModelBuilder builder);
    }
}
