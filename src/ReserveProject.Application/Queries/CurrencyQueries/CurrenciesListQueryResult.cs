using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Queries.Currency
{
    public class CurrenciesListQueryResult
    {
        public IEnumerable<CurrencyResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class CurrencyResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string Symbol { get; set; }
        }
    }

    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<CurrenciesListQuery>))]
    public class CurrenciesListQuery : IQuery<QueryExecutionResult<CurrenciesListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
