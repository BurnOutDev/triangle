using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.BankAccountQueries
{
    public class BankAccountListQueryResult
    {
        public List<BankAccountResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class BankAccountResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public Guid BankUId { get; set; }
            public string Bank { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<BankAccountListQuery>))]
    public class BankAccountListQuery : IQuery<QueryExecutionResult<BankAccountListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
