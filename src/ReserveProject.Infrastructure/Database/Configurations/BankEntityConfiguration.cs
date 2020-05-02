using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Aggregates.BankAggregate;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class BankEntityConfiguration : EntityConfiguration<Bank>
    {
        public override void Map(EntityTypeBuilder<Bank> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}