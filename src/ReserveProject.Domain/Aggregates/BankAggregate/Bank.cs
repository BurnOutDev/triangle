using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAggregate
{
    public class Bank : BaseEntity
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
        public virtual City City { get; set; }

        public Bank()
        {
        }

        public static Bank Create(string name, string identifierCode, string street, string streetInDetails, int cityId, string zipCode, bool isActive, string phone, string email)
        {
            var bank = new Bank()
            {
                Name = name,
                IdentifierCode = identifierCode,
                Street = street,
                StreetInDetails = streetInDetails,
                CityId = cityId,
                ZipCode = zipCode,
                IsActive = isActive,
                Phone = phone,
                Email = email
            };

            bank.Raise(new BankCreatedDomainEvent(bank.UId, bank.Name, bank.IdentifierCode, bank.Street,
                bank.StreetInDetails, bank.CityId, bank.ZipCode, bank.IsActive, bank.Phone, bank.Email));
            return bank;
        }

        public void Update(string name, string identifierCode, string street, string streetInDetails, int cityId, string zipCode, bool isActive, string phone, string email)
        {
            Name = name;
            IdentifierCode = identifierCode;
            Street = street;
            StreetInDetails = streetInDetails;
            CityId = cityId;
            ZipCode = zipCode;
            IsActive = isActive;
            Phone = phone;
            Email = email;

            Raise(new BankUpdatedDomainEvent(UId, Name, IdentifierCode, Street, StreetInDetails, CityId, ZipCode, IsActive, Phone, Email));
        }

        public override void Activate()
        {
            base.Activate();

            Raise(new BankDeletedDomainEvent(UId));
        }

    }
}
