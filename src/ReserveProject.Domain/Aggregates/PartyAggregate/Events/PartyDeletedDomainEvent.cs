using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class PartyDeletedDomainEvent : DomainEvent
    {
        public PartyDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
