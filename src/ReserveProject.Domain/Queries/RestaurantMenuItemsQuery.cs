using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class RestaurantMenuItemsQueryResult
    {
        public int RestaurantId { get; set; }
        public ICollection<RestaurantMenuItem> MenuItems { get; set; }

        public class RestaurantMenuItem
        {
            public int MenuItemId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public int CategoryId { get; set; }
            public int[] IngredientIds { get; set; }
            public decimal Price { get; set; }
            public bool Unavailable { get; set; }
        }
    }
}
