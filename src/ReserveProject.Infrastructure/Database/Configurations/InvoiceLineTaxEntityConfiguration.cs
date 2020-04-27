using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class InvoiceLineTaxEntityConfiguration : EntityConfiguration<InvoiceLineTax>
    {
        public override void Map(EntityTypeBuilder<InvoiceLineTax> builder)
        {
            builder.HasKey(ps => new { ps.InvoiceLineId, ps.TaxId });

            builder.HasOne(ps => ps.Tax)
                   .WithMany(c => c.TaxInvoiceLines)
                   .HasForeignKey(ps => ps.TaxId);

            builder.HasOne(ps => ps.InvoiceLine)
                   .WithMany(c => c.InvoiceLineTaxes)
                   .HasForeignKey(ps => ps.InvoiceLineId);
        }
    }
}
