using ReserveProject.Application.Shared;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ReserveProject.Application.Queries.BankQueries
{
    public class BankListQueryResult
    {
        public List<BankResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class BankResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string IdentifierCode { get; set; }
            public string Street { get; set; }
            public string StreetInDetails { get; set; }
            public Guid CityUId { get; set; }
            public string ZipCode { get; set; }
            public bool IsActive { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }

        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<BankListQuery>))]
    public class BankListQuery : IQuery<QueryExecutionResult<BankListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
