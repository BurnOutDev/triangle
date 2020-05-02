using ReserveProject.Shared.ApplicationInfrastructure;
using System;

namespace ReserveProject.Application.Queries.Currency
{

    public class CurrencyDetailsQuery : IQuery<QueryExecutionResult<CurrencyDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }
    public class CurrencyDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
