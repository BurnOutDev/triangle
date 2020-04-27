using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class ProductCategoryRepository : EfRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
