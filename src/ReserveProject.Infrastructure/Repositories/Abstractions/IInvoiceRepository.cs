using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
    }
}
