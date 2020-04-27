using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Application.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ReserveProject.Application.Queries.LocationQueries
{

    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<LocationListQuery>))]
    public class LocationListQuery : IQuery<QueryExecutionResult<LocationListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public int? PageSize { get; set; }

        public int? Page { get; set; }

        public string SearchText { get; set; }

        public FilterModel FilterModel { get; set; }

       

        public SortModel SortModel { get; set; }
    }
    public class LocationListQueryResult
    {
        public IEnumerable<LocationListResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class LocationListResult
        {
            public string Location { get; set; }
            public Guid CityUId { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
        }
    }
}
