﻿using ReserveProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands
{
    public class ReserveCommand
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string PromoCode { get; set; }
        public int SeatTypeId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PartySize { get; set; }
        public string Comment { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }

        public class MenuItem
        {
            public int MenuItemId { get; set; }
            public int Quantity { get; set; }
        }
    }
}