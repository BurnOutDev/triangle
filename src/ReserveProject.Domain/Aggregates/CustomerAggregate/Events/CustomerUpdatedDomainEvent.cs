using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }

        public CustomerUpdatedDomainEvent(Guid uId,string name)
        {
            UId = uId;
            Name = name;
        }
    }
}