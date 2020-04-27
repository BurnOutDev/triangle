using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Domain.Aggregates.BankAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
    }
}
