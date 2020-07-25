namespace ReserveProject.Domain.Queries
{
    public class RestaurantMenuItemQueryResult
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int[] IngredientIds { get; set; }
        public decimal Price { get; set; }
        public bool Unavailable { get; set; }
    }
}
