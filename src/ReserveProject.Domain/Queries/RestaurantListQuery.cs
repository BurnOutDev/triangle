using ReserveProject.Domain.Enums;
using System;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class RestaurantListItem
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Cuisine { get; set; }
        public PriceRange PriceRange { get; set; }
    }
}
