using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.TaxQueries
{
    public class TaxListQueryResult
    {
        public List<TaxResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class TaxResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public TaxScope Scope { get; set; }
            public TaxComputation Computation { get; set; }
            public decimal Value { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<TaxListQuery>))]
    public class TaxListQuery : IQuery<QueryExecutionResult<TaxListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
