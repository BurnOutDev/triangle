using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.PaymentTermQueries
{
    public class PaymentTermDetailsQuery : IQuery<QueryExecutionResult<PaymentTermDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class PaymentTermDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DaysCount { get; set; }
    }
}
