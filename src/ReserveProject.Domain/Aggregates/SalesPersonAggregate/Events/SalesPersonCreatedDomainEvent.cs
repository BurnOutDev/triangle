using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class SalesPersonCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }


        public SalesPersonCreatedDomainEvent(Guid uId, string name, string email, string phone, string mobile)
        {
            UId = uId;
            Name = name;
            Email = email;
            Phone = phone;
            Mobile = mobile;
        }
    }
}