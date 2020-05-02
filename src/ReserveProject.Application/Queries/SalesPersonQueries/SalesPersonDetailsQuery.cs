using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.SalesPersonQueries
{
    public class SalesPersonDetailsQuery : IQuery<QueryExecutionResult<SalesPersonDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class SalesPersonDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

    }
}
