using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class RestaurantsPerCategoryQuery
    {
        public string CategoryName { get; set; }
    }

    public class RestaurantsPerCategoryQueryResult
    {
        public string CategoryName { get; set; }
        public ICollection<RestaurantItem> Restaurants { get; set; }

        public class RestaurantItem
        {
            public string Title { get; set; }
            public string Address { get; set; }
            public string Cuisine { get; set; }
            public int PriceRange { get; set; }
            public string Image { get; set; }
            public string Rating { get; set; }
            public int ReviewsCount { get; set; }
        }
    }
}
