using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class SalesPersonDeletedDomainEvent : DomainEvent
    {
        public SalesPersonDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
