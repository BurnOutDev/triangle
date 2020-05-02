using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Queries.Location
{
    public class CountryDetailsQuery : IQuery<QueryExecutionResult<CountryDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class CountryDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
}
