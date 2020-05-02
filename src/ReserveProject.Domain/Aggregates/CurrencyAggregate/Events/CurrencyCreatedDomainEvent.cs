using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Events
{
    public class CurrencyCreatedDomainEvent : DomainEvent, IDomainEvent
    {
        public CurrencyCreatedDomainEvent(Guid uId, string name, string code, string symbol)
        {
            UId = uId;
            Name = name;
            Code = code;
            Symbol = symbol;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
