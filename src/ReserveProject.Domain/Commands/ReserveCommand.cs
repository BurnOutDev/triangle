using System;
using System.Collections.Generic;

namespace ReserveProject.Domain.Commands
{
    public class ReserveCommand
    {
        public int RestaurantId { get; set; }
        public string PromoCode { get; set; }
        public int SeatTypeId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PartySizeChildren { get; set; }
        public int PartySizeAdults { get; set; }
        public string Comment { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }

        public class MenuItem
        {
            public int MenuItemId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
