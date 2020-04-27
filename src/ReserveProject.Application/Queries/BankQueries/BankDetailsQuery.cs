using ReserveProject.Shared.ApplicationInfrastructure;
using System;

namespace ReserveProject.Application.Queries.BankQueries
{
    public class BankDetailsQuery : IQuery<QueryExecutionResult<BankDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class BankDetailsQueryResult
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
