using ReserveProject.Domain.Enums;
using System.Collections.Generic;
using System.Spatial;

namespace ReserveProject.Domain.Commands
{
    public class AddRestaurantCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public string BusinessId { get; set; }
        public string FacebookId { get; set; }

        public GeographyPoint Location { get; set; }

        public int CuisineId { get; set; }
        public PriceRange PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        public ICollection<WorkDay> BusinessHours { get; set; }
    }
}
