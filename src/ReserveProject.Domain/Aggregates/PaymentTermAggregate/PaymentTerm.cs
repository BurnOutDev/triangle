using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.PaymentTermAggregate
{
    public class PaymentTerm : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DaysCount { get; set; }

        public PaymentTerm()
        {
        }

        public static PaymentTerm Create(string name, string description, int daysCount)
        {
            var paymentTerm = new PaymentTerm()
            {
                Name = name,
                Description = description,
                DaysCount = daysCount
            };

            paymentTerm.Raise(new PaymentTermCreatedDomainEvent(paymentTerm.UId, paymentTerm.Name, paymentTerm.Description, paymentTerm.DaysCount));
            return paymentTerm;
        }

        public void Update(string name, string description, int daysCount)
        {
            Name = name;
            Description = description;
            DaysCount = daysCount;

            Raise(new PaymentTermUpdatedDomainEvent(UId, Name, Description, DaysCount));
        }

        public override void Delete()
        {
            base.Delete();

            Raise(new PaymentTermDeletedDomainEvent(UId));
        }
    }
}
