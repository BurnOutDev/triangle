using ReserveProject.Domain.Entities.Shared;
using ReserveProject.Domain.Enums;
using System.Collections.Generic;

namespace ReserveProject.Domain
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Location Location { get; set; }

        public virtual Cuisine Cuisine { get; set; }
        public PriceRange PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        public virtual ICollection<BusinessHours> BusinessHours { get; set; }
    }
}