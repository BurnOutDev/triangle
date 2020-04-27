using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Aggregates.CurrencyAggregate;
using ReserveProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class CurrencyEntityConfiguration : EntityConfiguration<Currency>
    {
        public override void Map(EntityTypeBuilder<Currency> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}
