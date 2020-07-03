using ReserveProject.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class ReservationsQueryResult
    {
        public int RestaurantId { get; set; }
        public ICollection<ReservationItem> Reservations { get; set; }

        public class ReservationItem
        {
            public int ReservationId { get; set; }
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhoneNumber { get; set; }

            public int RestaurantId { get; set; }

            public string Status { get; set; }
            public decimal PaidAmount { get; set; }
            public int? PromoId { get; set; }
            public string PromoName { get; set; }

            public decimal Price { get; set; }
            public string SeatType { get; set; }
            public int SeatTypeId { get; set; }

            public DateTime DateAndTime { get; set; }
            public int PartySize { get; set; }
            public string Comment { get; set; }

            public ICollection<MenuItem> MenuItems { get; set; }

            public class MenuItem
            {
                public int MenuItemId { get; set; }
                public int Quantity { get; set; }
                public decimal Price { get; set; }
            }
        }
    }
}
