using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.PersistenceInfrastructure;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class PartyEntityConfiguration : EntityConfiguration<Party>
    {
        public override void Map(EntityTypeBuilder<Party> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}