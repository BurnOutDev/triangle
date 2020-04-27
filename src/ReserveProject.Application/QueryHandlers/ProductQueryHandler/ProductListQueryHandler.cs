using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.ProductQueries;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.ProductQueries.ProductListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class ProductListQueryHandler : QueryHandler<ProductListQuery, ProductListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public ProductListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<ProductListQueryResult>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<Product>().Select(x => new ProductResult()
            {
                UId = x.UId,
                Name = x.Name,
                BarCode = x.BarCode,
                CategoryUId = x.Category.UId,
                Category = x.Category.Name,
                Cost = x.Cost,
                Role = x.Role,
                SalesPrice = x.SalesPrice,
                Type = x.Type,
                Taxes = x.ProductTaxes.Select(x => new ProductResult.TaxResult() { UId = x.Tax.UId, Name = x.Tax.Name })
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new ProductListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }
}