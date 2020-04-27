using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Domain.Enums;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class InvoiceLineEntityConfiguration : EntityConfiguration<InvoiceLine>
    {
        public override void Map(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
