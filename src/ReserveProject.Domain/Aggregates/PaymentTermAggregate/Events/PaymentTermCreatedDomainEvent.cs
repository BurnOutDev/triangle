using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class PaymentTermCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DaysCount { get; set; }

        public PaymentTermCreatedDomainEvent(Guid uId, string name, string description, int daysCount)
        {
            UId = uId;
            Name = name;
            Description = description;
            DaysCount = daysCount;
        }
    }
}