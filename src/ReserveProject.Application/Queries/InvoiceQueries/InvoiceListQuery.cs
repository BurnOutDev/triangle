using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.InvoiceQueries
{
    public class InvoiceListQueryResult
    {
        public List<InvoiceResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class InvoiceResult
        {
            public Guid UId { get; set; }
            public string InvoiceNumber { get; set; }
            public InvoiceStatus Status { get; set; }
            public Guid CustomerUId { get; set; }
            public string Customer { get; set; }
            public Guid PaymentTermUId { get; set; }
            public string PaymentTerm { get; set; }
            public DateTimeOffset StartDate { get; set; }
            public DateTimeOffset DueDate { get; set; }
            public Guid SalesPersonUId { get; set; }
            public string SalesPerson { get; set; }
            public decimal UnTaxedAmount { get; set; }
            public decimal TaxAmmount { get; set; }
            public decimal Total { get; set; }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<InvoiceListQuery>))]
    public class InvoiceListQuery : IQuery<QueryExecutionResult<InvoiceListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
