using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;

namespace ReserveProject.Persistence.Configurations
{
    public class ReviewConfiguration : EntityConfiguration<Review>
    {
        public override void Map(EntityTypeBuilder<Review> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
