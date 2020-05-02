using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.TaxAggregate
{
    public class Tax : BaseEntity
    {

        public string Name { get; set; }
        public TaxScope Scope { get; set; }
        public TaxComputation Computation { get; set; }
        public decimal Value { get; set; }
        public virtual IEnumerable<ProductTax> TaxProducts { get; set; }
        public virtual IEnumerable<InvoiceLineTax> TaxInvoiceLines { get; set; }

        public Tax()
        {
        }

        public static Tax Create(string name, TaxScope scope, TaxComputation computation, decimal value)
        {
            var tax = new Tax()
            {
                Name = name,
                Scope = scope,
                Computation = computation,
                Value = value
            };

            tax.Raise(new TaxCreatedDomainEvent(tax.UId, tax.Name, tax.Scope, tax.Computation, tax.Value));
            return tax;
        }

        public void Update(string name, TaxScope scope, TaxComputation computation, decimal value)
        {
            Name = name;
            Scope = scope;
            Computation = computation;
            Value = value;

            Raise(new TaxUpdatedDomainEvent(UId, Name, Scope, Computation, Value));
        }

        public override void Delete()
        {
            base.Delete();
            Raise(new TaxDeletedDomainEvent(UId));
        }
    }
}
