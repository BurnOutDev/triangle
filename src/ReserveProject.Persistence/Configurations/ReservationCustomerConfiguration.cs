using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Domain;
using ReserveProject.Domain.Enums;
using ReserveProject.Persistence.Configurations.Shared;

namespace ReserveProject.Persistence.Configurations
{
    public class ReservationCustomerConfiguration : EntityConfiguration<ReservationCustomer>
    {
        public override void Map(EntityTypeBuilder<ReservationCustomer> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, nameof(b.EntityStatus)) == EntityStatus.Active);
        }
    }
}
