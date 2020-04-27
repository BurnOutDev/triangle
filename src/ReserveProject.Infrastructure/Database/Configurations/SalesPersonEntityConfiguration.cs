using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class SalesPersonEntityConfiguration : EntityConfiguration<SalesPerson>
    {
        public override void Map(EntityTypeBuilder<SalesPerson> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}