using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAccountAggregate
{
    public class BankAccount : BaseEntity
    {

        public string Name { get; set; }
        public string Number { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        //public int? PartyId { get; set; }
        //public virtual Party Party { get; set; }


        public BankAccount()
        {
        }

        public static BankAccount Create(string name, string number, int bankId)
        {
            var bankAccount = new BankAccount()
            {
                Name = name,
                BankId = bankId,
                Number = number
            };

            bankAccount.Raise(new BankAccountCreatedDomainEvent(bankAccount.UId, bankAccount.Name, bankAccount.Number, bankAccount.BankId));
            return bankAccount;
        }

        public void Update(string name, string number, int bankId)
        {
            Name = name;
            Number = number;
            BankId = bankId;
            Raise(new BankAccountUpdatedDomainEvent(UId, Name, Number, BankId));
        }

        public override void Delete()
        {
            base.Delete();
            Raise(new BankAccountDeletedDomainEvent(UId));
        }
    }
}
