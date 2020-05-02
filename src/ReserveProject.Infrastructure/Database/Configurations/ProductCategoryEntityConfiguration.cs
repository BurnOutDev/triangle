using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class ProductCategoryEntityConfiguration : EntityConfiguration<ProductCategory>
    {
        public override void Map(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}