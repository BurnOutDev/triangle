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
    public class InvoiceEntityConfiguration : EntityConfiguration<Invoice>
    {
        public override void Map(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasQueryFilter(b => EF.Property<EntityStatus>(b, "EntityStatus") == EntityStatus.Active);
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.PaymentTerm).WithMany().HasForeignKey(x => x.PaymentTermId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SalesPerson).WithMany().HasForeignKey(x => x.SalesPersonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
