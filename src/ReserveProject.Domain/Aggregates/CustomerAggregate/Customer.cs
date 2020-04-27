using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public Customer()
        {
        }

        public static Customer Create(string name)
        {
            var customer = new Customer()
            {
                Name = name
            };

            customer.Raise(new CustomerCreatedDomainEvent(customer.UId, customer.Name));
            return customer;
        }

        public void Update(string name)
        {
            Name = name;
            Raise(new CustomerUpdatedDomainEvent(UId, Name));
        }

        public override void Delete()
        {
            base.Delete();
            Raise(new CustomerDeletedDomainEvent(UId));
        }
    }
}
