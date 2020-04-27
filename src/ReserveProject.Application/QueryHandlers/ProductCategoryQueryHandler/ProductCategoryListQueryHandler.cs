using ReserveProject.Application.Infrastructure;
using ReserveProject.Application.Queries.ProductCategoryQueries;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ReserveProject.Application.Queries.ProductCategoryQueries.ProductCategoryListQueryResult;

namespace ReserveProject.Application.QueryHandlers
{
    public class ProductCategoryListQueryHandler : QueryHandler<ProductCategoryListQuery, ProductCategoryListQueryResult>
    {
        private readonly PrimeDbContext _invoicingDbContext;

        public ProductCategoryListQueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }

        public async override Task<QueryExecutionResult<ProductCategoryListQueryResult>> Handle(ProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = _invoicingDbContext.Set<ProductCategory>().Select(x => new ProductCategoryResult()
            {
                UId = x.UId,
                Name = x.Name,
                ParentUId = x.Parent == null ? Guid.Empty : x.Parent.UId,
                Parent = x.Parent == null ? null : x.Parent.Name
            }).Filter(request.FilterModel).Sort(request.SortModel);

            return await Ok(new ProductCategoryListQueryResult()
            {
                Items = result.Page(request).ToList(),
                ItemsCount = result.Count()
            });
        }
    }

}
