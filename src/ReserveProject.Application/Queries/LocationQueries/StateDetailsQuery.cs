using ReserveProject.Shared.ApplicationInfrastructure;
using System;

namespace ReserveProject.Application.Queries.Location
{
    public class StateDetailsQuery : IQuery<QueryExecutionResult<StateDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class StateDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid CountryUId { get; set; }
    }
}
