using ReserveProject.Domain.Queries;

namespace ReserveProject.Client.Models
{
    public class MenuItemsViewModel
    {
        public IngredientsQueryResult IngredientsQuery { get; set; }

        public RestaurantMenuItemsQueryResult MenuItems { get; set; }

        public CategoriesQueryResult CategoriesQuery { get; set; }

    }
}
