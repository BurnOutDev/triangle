using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.ProductCategoryQueries;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.QueryHandlers
{
    public class ProductCategoryDetailsQueryHandler : QueryHandler<ProductCategoryDetailsQuery, ProductCategoryDetailsQueryResult>
    {
        public ProductCategoryDetailsQueryHandler(PrimeDbContext invoicingDbContext)
            : base(invoicingDbContext)
        {
        }

        public override async Task<QueryExecutionResult<ProductCategoryDetailsQueryResult>> Handle(ProductCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = Entity<ProductCategory>(request.UId);

            return await Ok(new ProductCategoryDetailsQueryResult()
            {
                UId = result.UId,
                Name = result.Name,
                ParentUId = result.Parent?.UId,
                Parent = result.Parent?.Name
            });
        }
    }

}
