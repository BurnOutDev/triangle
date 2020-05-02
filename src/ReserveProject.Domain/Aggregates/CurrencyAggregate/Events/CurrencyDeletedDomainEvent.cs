using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Events
{
    public class CurrencyDeletedDomainEvent : DomainEvent, IDomainEvent
    {
        public CurrencyDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }
    }
}
