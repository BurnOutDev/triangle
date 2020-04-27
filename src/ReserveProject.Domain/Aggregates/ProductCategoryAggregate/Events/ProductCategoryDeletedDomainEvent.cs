using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductCategoryDeletedDomainEvent : DomainEvent
    {
        public ProductCategoryDeletedDomainEvent(Guid uId)
        {
            UId = uId;
        }

    }
}
