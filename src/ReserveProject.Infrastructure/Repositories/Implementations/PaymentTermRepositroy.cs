using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class PaymentTermRepositroy : EfRepository<PaymentTerm>, IPaymentTermRepository
    {
        public PaymentTermRepositroy(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
