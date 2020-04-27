using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class ProductEntityConfiguration : EntityConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}