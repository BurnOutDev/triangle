using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.TaxQueries
{
    public class TaxDetailsQuery : IQuery<QueryExecutionResult<TaxDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class TaxDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public TaxScope Scope { get; set; }
        public TaxComputation Computation { get; set; }
        public decimal Value { get; set; }
    }
}
