using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Shared.PagingAndFilter;
using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Queries.LocationQueries
{
    public class StatesListQueryResult
    {
        public IEnumerable<StateResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class StateResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
        }
    }

    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<StatesListQuery>))]
    public class StatesListQuery : IQuery<QueryExecutionResult<StatesListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }
       
    }


}
