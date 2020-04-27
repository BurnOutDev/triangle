using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.BankAccountQueries
{
    public class BankAccountDetailsQuery : IQuery<QueryExecutionResult<BankAccountDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class BankAccountDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public Guid BankUId { get; set; }
        public string Bank { get; set; }
    }
}
