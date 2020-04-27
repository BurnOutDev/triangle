using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class TaxCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public TaxScope Scope { get; set; }
        public TaxComputation Computation { get; set; }
        public decimal Value { get; set; }

        public TaxCreatedDomainEvent(Guid uId, string name, TaxScope scope, TaxComputation computation, decimal value)
        {
            UId = uId;
            Name = name;
            Scope = scope;
            Computation = computation;
            Value = value;
        }
    }
}