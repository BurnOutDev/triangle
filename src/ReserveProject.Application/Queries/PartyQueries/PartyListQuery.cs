using ReserveProject.Application.Shared;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.PagingAndFilter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.PartyQueries
{
    public class PartyListQueryResult
    {
        public List<PartyResult> Items { get; set; }
        public int ItemsCount { get; set; }

        public class PartyResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
            public PartyType Type { get; set; }
            public string Street { get; set; }
            public string StreetDetails { get; set; }
            public Guid CityUId { get; set; }
            public string TaxCode { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public Language Language { get; set; }
            public PartyRole Role { get; set; }

            public virtual IEnumerable<BankAccountResult> BankAccounts { get; set; }
            public string City { get; set; }

            public class BankAccountResult
            {
                public Guid UId { get; set; }
                public string Name { get; set; }
            }
        }
    }
    [ModelBinder(BinderType = typeof(FilterableQueryModelBinder<PartyListQuery>))]
    public class PartyListQuery : IQuery<QueryExecutionResult<PartyListQueryResult>>, IPagedQuery, IFilterable, ISortable
    {
        public SortModel SortModel { get; set; }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public FilterModel FilterModel { get; set; }

    }
}
