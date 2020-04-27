using System;
using System.Collections.Generic;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class PartyCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public PartyType Type { get; set; }
        public string Street { get; set; }
        public string StreetDetails { get; set; }
        public int CityId { get; set; }
        public string TaxCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Language Language { get; set; }
        public PartyRole Role { get; set; }
        public IEnumerable<int> BankAccountIds { get; set; }

        public PartyCreatedDomainEvent(Guid uId, string name, PartyRole role, PartyType type, string street, string streetDetails,
            int cityId, Language language, string taxCode, string phone, string mobile, string email, IEnumerable<int> bankAccountIds)
        {
            UId = uId;
            Name = name;
            Role = role;
            Type = type;
            Street = street;
            StreetDetails = streetDetails;
            CityId = cityId;
            Language = language;
            TaxCode = taxCode;
            Phone = phone;
            Mobile = mobile;
            Email = email;
            BankAccountIds = bankAccountIds;
        }
    }
}