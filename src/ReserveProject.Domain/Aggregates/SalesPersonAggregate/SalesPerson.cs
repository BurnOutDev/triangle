using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.SalesPersonAggregate
{
    public class SalesPerson : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public SalesPerson()
        {
        }

        public static SalesPerson Create(string name, string email, string phone, string mobile)
        {
            var salesPerson = new SalesPerson()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Mobile = mobile
            };

            salesPerson.Raise(new SalesPersonCreatedDomainEvent(salesPerson.UId, salesPerson.Name, salesPerson.Email, salesPerson.Phone, salesPerson.Mobile));
            return salesPerson;
        }

        public void Update(string name, string email, string phone, string mobile)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Mobile = mobile;

            Raise(new SalesPersonUpdatedDomainEvent(UId, Name, Email, Phone, Mobile));
        }

        public override void Delete()
        {
            base.Delete();

            Raise(new SalesPersonDeletedDomainEvent(UId));
        }
    }
}
