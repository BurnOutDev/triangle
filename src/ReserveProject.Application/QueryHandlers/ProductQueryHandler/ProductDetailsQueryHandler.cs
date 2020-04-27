using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.ProductQueries;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class ProductDetailsQueryHandler : QueryHandler<ProductDetailsQuery, ProductDetailsQueryResult>
    {
        public ProductDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<ProductDetailsQueryResult>> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<Product>(request.UId);

            return await Ok(new ProductDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                BarCode = result.BarCode,
                CategoryUId = result.Category.UId,
                Category = result.Category.Name,
                Cost = result.Cost,
                Role = result.Role,
                Type = result.Type,
                SalesPrice = result.SalesPrice,
                Taxes = result.ProductTaxes.Select(x => new ProductDetailsQueryResult.TaxResult() { UId = x.Tax.UId, Name = x.Tax.Name })
            });
        }
    }

}
