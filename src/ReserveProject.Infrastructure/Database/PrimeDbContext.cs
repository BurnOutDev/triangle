using ReserveProject.Infrastructure.Database.Configurations;
using ReserveProject.Infrastructure.Database.Configurations.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ReserveProject.Infrastructure.Database
{
    public class PrimeDbContext : DbContext
    {
        public PrimeDbContext()
        {
        }

        public PrimeDbContext(DbContextOptions<PrimeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new CustomerEntityConfiguration());
            builder.AddConfiguration(new EventEntityConfiguration());
            builder.AddConfiguration(new TaxEntityConfiguration());
            builder.AddConfiguration(new CityEntityConfiguration());
            builder.AddConfiguration(new CountryEntityConfiguration());
            builder.AddConfiguration(new StateEntityConfiguration());
            builder.AddConfiguration(new BankEntityConfiguration());
            builder.AddConfiguration(new BankAccountEntityConfiguration());
            builder.AddConfiguration(new PaymentTermEntityConfiguration());
            builder.AddConfiguration(new ProductCategoryEntityConfiguration());
            builder.AddConfiguration(new SalesPersonEntityConfiguration());
            builder.AddConfiguration(new ProductEntityConfiguration());
            builder.AddConfiguration(new ProductTaxEntityConfiguration());
            builder.AddConfiguration(new PartyEntityConfiguration());
            builder.AddConfiguration(new InvoiceLineEntityConfiguration());
            builder.AddConfiguration(new InvoiceLineTaxEntityConfiguration());
            builder.AddConfiguration(new InvoiceEntityConfiguration());
            builder.AddConfiguration(new CurrencyEntityConfiguration());

        }

    }

}