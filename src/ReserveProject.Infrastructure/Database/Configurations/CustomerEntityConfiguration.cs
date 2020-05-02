using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class CustomerEntityConfiguration : EntityConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}