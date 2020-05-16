using ReserveProject.Domain.Entities.Shared;
using ReserveProject.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ReserveProject.Domain
{
    public class Reservation : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal PaidAmount { get; set; }
        public virtual Promo Promo { get; set; }
        public decimal Price { get; set; }
        public virtual SeatType SeatType { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PartySize { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ReservationMenuItem> MenuItems { get; set; }
    }
}
