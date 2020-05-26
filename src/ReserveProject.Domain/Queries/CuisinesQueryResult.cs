using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class CuisinesQueryResult
    {
        public ICollection<CuisineItem> Cuisines { get; set; }

        public class CuisineItem
        {
            public int CuisineId { get; set; }
            public string Title { get; set; }
            public int RestaurantQuantity { get; set; }
            public string Image { get; set; }
        }
    }
}
