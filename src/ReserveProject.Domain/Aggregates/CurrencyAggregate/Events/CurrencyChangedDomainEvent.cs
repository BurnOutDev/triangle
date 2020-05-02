using System;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Events
{
    public class CurrencyChangedDomainEvent : DomainEvent, IDomainEvent
    {
        public CurrencyChangedDomainEvent(Guid uId, string name, string code, string symbol)
        {
            UId = UId;
            Name = name;
            Code = code;
            Symbol = symbol;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
