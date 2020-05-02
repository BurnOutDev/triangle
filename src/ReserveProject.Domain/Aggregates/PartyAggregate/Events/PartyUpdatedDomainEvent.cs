using System;
using System.Collections.Generic;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class PartyUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public PartyType Type { get; set; }
        public string Street { get; set; }
        public string StreetDetails { get; set; }
        public int CityId { get; set; }
        public string BankAccountCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Language Language { get; set; }
        public PartyRole Role { get; set; }

        public PartyUpdatedDomainEvent(Guid uId, string name, PartyRole role, PartyType type, string street, string streetDetails,
            int cityId, Language language, string taxCode, string phone, string mobile, string email)
        {
            UId = uId;
            Name = name;
            Role = role;
            Type = type;
            Street = street;
            StreetDetails = streetDetails;
            CityId = cityId;
            Language = language;
            BankAccountCode = taxCode;
            Phone = phone;
            Mobile = mobile;
            Email = email;
        }
    }

    public class BankAccountAddedToPartyDomainEvent : DomainEvent
    {
        public int  BankAccountId { get; set; }
        public BankAccountAddedToPartyDomainEvent(Guid uId,int bankAccountId)
        {
            UId = uId;
            BankAccountId = bankAccountId;
        }
    }
    public class BankAccountDeletedFromPartyDomainEvent : DomainEvent
    {
        public int BankAccountId { get; set; }
        public BankAccountDeletedFromPartyDomainEvent(Guid uId, int bankAccountId)
        {
            UId = uId;
            BankAccountId = bankAccountId;
        }
    }
}