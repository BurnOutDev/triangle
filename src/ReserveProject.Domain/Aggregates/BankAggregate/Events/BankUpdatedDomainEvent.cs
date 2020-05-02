using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class BankUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public string IdentifierCode { get; set; }
        public string Street { get; set; }
        public string StreetInDetails { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public BankUpdatedDomainEvent(Guid uId, string name, string identifierCode, string street, string streetInDetails, int cityId, string zipCode, bool isActive, string phone, string email)
        {
            UId = uId;
            Name = name;
            IdentifierCode = identifierCode;
            Street = street;
            StreetInDetails = streetInDetails;
            CityId = cityId;
            ZipCode = zipCode;
            IsActive = isActive;
            Phone = phone;
            Email = email;
        }
    }
}