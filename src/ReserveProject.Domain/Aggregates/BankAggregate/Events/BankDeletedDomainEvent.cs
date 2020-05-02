using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class BankDeletedDomainEvent : DomainEvent
    {
        public BankDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
