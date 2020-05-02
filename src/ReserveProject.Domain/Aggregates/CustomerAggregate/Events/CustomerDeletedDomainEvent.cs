using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerDeletedDomainEvent : DomainEvent
    {
        public CustomerDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
