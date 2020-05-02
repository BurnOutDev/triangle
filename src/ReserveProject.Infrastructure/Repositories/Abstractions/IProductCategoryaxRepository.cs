using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }
}
