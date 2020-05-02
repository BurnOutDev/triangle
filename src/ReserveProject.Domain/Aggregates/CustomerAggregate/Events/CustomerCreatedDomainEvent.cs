using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class CustomerCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }

        public CustomerCreatedDomainEvent(Guid uId, string name)
        {
            UId = uId;
            Name = name;
        }
    }
}