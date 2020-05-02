using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReserveProject.Infrastructure.Database.Configurations.Infrastructure
{
    public abstract class EntityConfiguration<T> : IEntityMappingConfiguration<T>
        where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Map(ModelBuilder builder)
        {
            Map(builder.Entity<T>());
        }
    }
}