using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class PaymentTermDeletedDomainEvent : DomainEvent
    {
        public PaymentTermDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
