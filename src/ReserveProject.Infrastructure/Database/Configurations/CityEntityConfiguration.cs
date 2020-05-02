using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class CityEntityConfiguration : EntityConfiguration<City>
    {
        public override void Map(EntityTypeBuilder<City> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}