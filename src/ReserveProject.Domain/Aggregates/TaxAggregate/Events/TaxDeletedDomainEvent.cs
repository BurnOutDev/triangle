using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class TaxDeletedDomainEvent : DomainEvent
    {
        public TaxDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
