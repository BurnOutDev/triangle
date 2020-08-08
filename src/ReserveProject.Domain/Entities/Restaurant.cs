﻿using ReserveProject.Domain.Entities.Shared;
using ReserveProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Spatial;

namespace ReserveProject.Domain
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public string BusinessId { get; set; }
        public string FacebookId { get; set; }

        public string ImageUrl { get; set; }

        public string Address { get; set; }
        public string AddressLongtitude { get; set; }
        public string AddressLatitude { get; set; }

        public virtual Cuisine Cuisine { get; set; }
        public virtual int CuisineId { get; set; }
        public PriceRange PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        public virtual ICollection<BusinessHours> BusinessHours { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<RestaurantMedia> RestaurantMedia { get; set; }
    }
}