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

        public string Image { get; set; }

        public string Address { get; set; }
        public string AddressLongtitude { get; set; }
        public string AddressLatitude { get; set; }

        public int CuisineId { get; set; }
        public PriceRange PriceRange { get; set; }

        public bool HasParking { get; set; }
        public bool IsCardPaymentAvailable { get; set; }

        public ICollection<WorkDay> BusinessHours { get; set; }
    }
}
