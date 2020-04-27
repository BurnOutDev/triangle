using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
        }
    }
}
