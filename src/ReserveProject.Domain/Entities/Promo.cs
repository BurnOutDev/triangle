using ReserveProject.Domain.Entities.Shared;
using System;

namespace ReserveProject.Domain
{
    public class Promo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Code { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime DeactivationDate { get; set; }
    }
}

//