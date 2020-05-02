using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Queries.Location
{
    public class CityDetailsQuery : IQuery<QueryExecutionResult<CityDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class CityDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Guid CountryUId { get; set; }
        public string State { get; set; }
        public Guid StateUId { get; set; }
    }
}
