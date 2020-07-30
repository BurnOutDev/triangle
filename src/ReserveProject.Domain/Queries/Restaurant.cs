using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class RestaurantQuery
    {
        public int RestaurantId { get; set; }
    }

    public class RestaurantQueryResult
    {
        public int RestaurantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Cuisine { get; set; }
        public int PriceRange { get; set; }
        public string Image { get; set; }
        public string Rating { get; set; }
        public int ReviewsCount { get; set; }
    }
}
