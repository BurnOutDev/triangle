using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class BankAccountEntityConfiguration : EntityConfiguration<BankAccount>
    {
        public override void Map(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.Bank).WithMany().HasForeignKey(x => x.BankId).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.Party).WithMany().HasForeignKey(x => x.PartyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}