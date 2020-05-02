using ReserveProject.Domain.Aggregates.CurrencyAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
    }
}
