using Microsoft.AspNetCore.Mvc;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;

namespace ReserveProject.Application.Queries.LocationQueries
{
    public class CitiesListQueryResult
    {
        public IEnumerable<CityResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class CityResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public Guid CountryUId { get; set; }
            public string Country { get; set; }
            public Guid StateUId { get; set; }
            public string State { get; set; }
        }
    }

    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<CitiesListQuery>))]
    public class CitiesListQuery : IQuery<QueryExecutionResult<CitiesListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }
       
    }
}
