using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductDeletedDomainEvent : DomainEvent
    {
        public ProductDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
