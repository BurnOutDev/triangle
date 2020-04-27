﻿using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class BankAccountUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int BankId { get; set; }

        public BankAccountUpdatedDomainEvent(Guid uId, string name, string number, int bankId)
        {
            UId = uId;
            Name = name;
            Number = number;
            BankId = bankId;
        }
    }
}