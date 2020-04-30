using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;

namespace ReserveProject.Persistence.Configurations
{
    public class RestaurantMediaConfiguration : EntityConfiguration<RestaurantMedia>
    {
        public override void Map(EntityTypeBuilder<RestaurantMedia> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
