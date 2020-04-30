using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReserveProject.Persistence.Configurations.Shared
{
    public interface IEntityMappingConfiguration<T> : IEntityConfiguration
      where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
