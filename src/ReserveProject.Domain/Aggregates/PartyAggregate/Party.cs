using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Aggregates.PartyAggregate
{
    public class Party : BaseEntity
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

        public virtual List<BankAccount> BankAccounts { get; set; }
        public virtual City City { get; set; }

        public Party()
        {
        }

        public static Party Create(string name, PartyType type, string street, string streetDetails, PartyRole role,
            int cityId, string taxCode, string phone, string mobile, string email, Language language, List<BankAccount> bankAccounts)
        {
            var party = new Party()
            {
                Name = name,
                Type = type,
                Street = street,
                StreetDetails = streetDetails,
                CityId = cityId,
                TaxCode = taxCode,
                Phone = phone,
                Mobile = mobile,
                Email = email,
                Language = language,
                Role = role,
                BankAccounts = bankAccounts
            };

            party.Raise(new PartyCreatedDomainEvent(party.UId, party.Name, party.Role, party.Type, party.Street, party.StreetDetails,
                party.CityId, party.Language, party.TaxCode, party.Phone, party.Mobile, party.Email, party.BankAccounts.Select(x => x.Id)));
            return party;

        }

        public void Update(string name, PartyType type, string street, string streetDetails, PartyRole role,
            int cityId, string taxCode, string phone, string mobile, string email, Language language)
        {
            Name = name;
            Type = type;
            Street = street;
            StreetDetails = streetDetails;
            CityId = cityId;
            TaxCode = taxCode;
            Phone = phone;
            Mobile = mobile;
            Email = email;
            Language = language;
            Role = role;

            Raise(new PartyUpdatedDomainEvent(UId, Name, Role, Type, Street, StreetDetails, CityId, Language, TaxCode, Phone, Mobile, Email));

        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            if (BankAccounts.Any(x => x.Id == bankAccount.Id))
                throw new DomainException("Party already has this bank account");
            BankAccounts.Add(bankAccount);

            Raise(new BankAccountAddedToPartyDomainEvent(UId, bankAccount.Id));
        }

        public void DeleteBankAccount(BankAccount bankAccount)
        {
            if (BankAccounts.Any(x => x.Id == bankAccount.Id))
                throw new DomainException("Party doesn't have this bank account");
            BankAccounts.Remove(bankAccount);

            Raise(new BankAccountDeletedFromPartyDomainEvent(UId, bankAccount.Id));
        }

        public override void Delete()
        {
            base.Delete();

            Raise(new PartyDeletedDomainEvent(UId));
        }
    }
}
