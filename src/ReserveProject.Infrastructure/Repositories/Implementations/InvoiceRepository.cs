using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class InvoiceRepository:EfRepository<Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(PrimeDbContext invoicingDbContext):base(invoicingDbContext)
        {
        }
    }
}
