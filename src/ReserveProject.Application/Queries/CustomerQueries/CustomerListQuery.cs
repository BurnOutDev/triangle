using Microsoft.AspNetCore.Mvc;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;

namespace ReserveProject.Application.Queries.CustomerQueries
{
    public class CustomerListQueryResult
    {
        public List<CustomerResult> Items { get; set; }
        public int ItemsCount { get; set; }
        public class CustomerResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<CustomerListQuery>))]
    public class CustomerListQuery : IQuery<QueryExecutionResult<CustomerListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }
       
    }
}