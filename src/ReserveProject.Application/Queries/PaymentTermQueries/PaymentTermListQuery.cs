using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.PaymentTermQueries
{
    public class PaymentTermListQueryResult
    {
        public List<PaymentTermResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class PaymentTermResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int DaysCount { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<PaymentTermListQuery>))]
    public class PaymentTermListQuery : IQuery<QueryExecutionResult<PaymentTermListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
