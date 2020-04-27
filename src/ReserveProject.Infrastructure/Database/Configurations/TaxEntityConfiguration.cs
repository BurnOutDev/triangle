using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class TaxEntityConfiguration : EntityConfiguration<Tax>
    {
        public override void Map(EntityTypeBuilder<Tax> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}