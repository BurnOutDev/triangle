using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class PaymentTermEntityConfiguration : EntityConfiguration<PaymentTerm>
    {
        public override void Map(EntityTypeBuilder<PaymentTerm> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
        }
    }
}