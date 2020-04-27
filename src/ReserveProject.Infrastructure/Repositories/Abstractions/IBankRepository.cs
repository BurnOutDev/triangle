using ReserveProject.Domain.Aggregates.BankAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IBankRepository : IRepository<Bank>
    {
    }
}
