using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Queries.LocationQueries
{
    public class CountriesListQueryResult
    {
        public IEnumerable<CountryResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class CountryResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string CountryCode { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<CountriesListQuery>))]
    public class CountriesListQuery : IQuery<QueryExecutionResult<CountriesListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public string SearchQuery { get ; set ; }
        public FilterModel FilterModel { get ; set; }
    }

}
