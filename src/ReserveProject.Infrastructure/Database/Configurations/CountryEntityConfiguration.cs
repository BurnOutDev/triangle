using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class CountryEntityConfiguration : EntityConfiguration<Country>
    {
        public override void Map(EntityTypeBuilder<Country> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}