using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface ISalesPersonRepository : IRepository<SalesPerson>
    {
    }
}
