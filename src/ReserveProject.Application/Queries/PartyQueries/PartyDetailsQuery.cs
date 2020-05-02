using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.PartyQueries
{
    public class PartyDetailsQuery : IQuery<QueryExecutionResult<PartyDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class PartyDetailsQueryResult
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
