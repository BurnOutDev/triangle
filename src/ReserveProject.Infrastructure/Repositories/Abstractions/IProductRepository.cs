using ReserveProject.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
