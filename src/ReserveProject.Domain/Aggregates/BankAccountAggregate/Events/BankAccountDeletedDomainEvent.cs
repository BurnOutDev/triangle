using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class BankAccountDeletedDomainEvent : DomainEvent
    {
        public BankAccountDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
