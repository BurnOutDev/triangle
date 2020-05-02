using ReserveProject.Domain.Aggregates.ProductAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;

namespace ReserveProject.Infrastructure.Database.Configurations
{
    public class ProductTaxEntityConfiguration : EntityConfiguration<ProductTax>
    {
        public override void Map(EntityTypeBuilder<ProductTax> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.TaxId });

            builder.HasOne(ps => ps.Tax)
                   .WithMany(c => c.TaxProducts)
                   .HasForeignKey(ps => ps.TaxId);

            builder.HasOne(ps => ps.Product)
                   .WithMany(c => c.ProductTaxes)
                   .HasForeignKey(ps => ps.ProductId);
        }
    }
}
