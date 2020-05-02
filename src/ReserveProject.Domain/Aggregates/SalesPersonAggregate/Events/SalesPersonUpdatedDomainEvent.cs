using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class SalesPersonUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }


        public SalesPersonUpdatedDomainEvent(Guid uId, string name, string email, string phone, string mobile)
        {
            UId = uId;
            Name = name;
            Phone = phone;
            Mobile = mobile;
        }
    }
}