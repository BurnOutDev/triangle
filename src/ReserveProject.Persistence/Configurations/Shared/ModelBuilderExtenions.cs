using Microsoft.EntityFrameworkCore;
using ReserveProject.Persistence.Configurations.Shared;

namespace ReserveProject.Persistence.Configurations
{
    public static class ModelBuilderExtenions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder,
            EntityConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
