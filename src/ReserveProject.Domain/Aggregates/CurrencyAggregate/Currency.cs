using System;
using System.ComponentModel.DataAnnotations;
using ReserveProject.Domain.Aggregates.CurrencyAggregate.Events;
using ReserveProject.Domain.Shared.Abstract;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate
{
    public class Currency : BaseEntity
    {
        public string Name { get; private set; }

        [MaxLength(3, ErrorMessage = "Only three characters allowed for currency code.")]
        public string Code { get; private set; }

        [MaxLength(1, ErrorMessage = "Only one character allowed for currency symbol.")]
        public string Symbol { get; private set; }

        public static Currency Create(string name, string code, string symbol)
        {
            Currency currency = new Currency { Name = name, Code = code, Symbol = symbol };

            if (!string.IsNullOrEmpty(code) && code.Length > 3)
            {
                currency.ThrowDomainException("Only three characters allowed for currency code.");
            }

            if (!string.IsNullOrEmpty(symbol) && symbol.Length > 1)
            {
                currency.ThrowDomainException("Only one character allowed for currency symbol.");
            }

            currency.Raise(new CurrencyCreatedDomainEvent(currency.UId, currency.Name, currency.Code, currency.Symbol));

            return currency;
        }

        protected Currency()
        {
            //
        }

        public void Edit(Guid uId, string name, string code, string symbol)
        {
            if (!string.IsNullOrEmpty(code) && code.Length > 3)
            {
                ThrowDomainException("Only three characters allowed for currency code.");
            }

            if (!string.IsNullOrEmpty(symbol) && symbol.Length > 1)
            {
                ThrowDomainException("Only one character allowed for currency symbol.");
            }

            Name = name;
            Code = code;
            Symbol = symbol;

            Raise(new CurrencyChangedDomainEvent(uId, name, code, symbol));
        }

        public override void Delete()
        {
            base.Delete();
            Raise(new CurrencyDeletedDomainEvent(UId));
        }
    }
}
