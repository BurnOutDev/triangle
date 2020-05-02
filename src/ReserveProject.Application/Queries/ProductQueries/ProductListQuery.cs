using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.ProductQueries
{
    public class ProductListQueryResult
    {
        public List<ProductResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class ProductResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public ProductRole Role { get; set; }
            public ProductType Type { get; set; }
            public string BarCode { get; set; }
            public Guid CategoryUId { get; set; }
            public decimal SalesPrice { get; set; }
            public decimal Cost { get; set; }
            public string Category { get; set; }
            public virtual IEnumerable<TaxResult> Taxes { get; set; }

            public class TaxResult
            {
                public Guid UId { get; set; }
                public string Name { get; set; }
            }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<ProductListQuery>))]
    public class ProductListQuery : IQuery<QueryExecutionResult<ProductListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
