using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.ProductCategoryQueries
{
    public class ProductCategoryListQueryResult
    {
        public List<ProductCategoryResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class ProductCategoryResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public Guid? ParentUId { get; set; }
            public string Parent { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<ProductCategoryListQuery>))]
    public class ProductCategoryListQuery : IQuery<QueryExecutionResult<ProductCategoryListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
