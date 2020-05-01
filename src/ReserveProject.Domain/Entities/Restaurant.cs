using ReserveProject.Domain.Entities.Shared;
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

        public static Restaurant Create(string name, string description, string phoneNumber, string websiteUrl, string email, string businessId, string facebookId, int cuisineId, PriceRange priceRange, bool hasParking, bool isCardPaymentAvailable)
        {
            return new Restaurant
            {
                Name = name,
                Description = description,
                PhoneNumber = phoneNumber,
                WebsiteUrl = websiteUrl,
                Email = email,
                BusinessId = businessId,
                FacebookId = facebookId,
                HasParking = hasParking,
                IsCardPaymentAvailable = isCardPaymentAvailable,
                PriceRange = priceRange,
                Cuisine = new Cuisine
                {
                    Id = cuisineId
                }
            }; 
        }

        public virtual Cuisine Cuisine { get; set; }
        public PriceRange PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        public virtual ICollection<BusinessHours> BusinessHours { get; set; }
    }
}