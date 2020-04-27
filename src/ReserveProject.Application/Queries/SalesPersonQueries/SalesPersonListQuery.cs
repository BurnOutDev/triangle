using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.SalesPersonQueries
{
    public class SalesPersonListQueryResult
    {
        public List<SalesPersonResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class SalesPersonResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }

        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<SalesPersonListQuery>))]
    public class SalesPersonListQuery : IQuery<QueryExecutionResult<SalesPersonListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
