using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Converters
{
    public static class MenuItemExtensions
    {
        public static RestaurantMenuItemsQueryResult.RestaurantMenuItem ToQueryResult(this MenuItem x)
        {
            var result = new RestaurantMenuItemsQueryResult.RestaurantMenuItem
            {
                CategoryId = x.Category.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IngredientIds = x.MenuItemIngredients.Select(ingredient => ingredient.Id).ToArray(),
                Name = x.Name,
                Price = x.Price,
                Unavailable = x.Unavailable,
                MenuItemId = x.Id,
                CategoryName = x.Category.Name
            };

            return result;
        }

        public static RestaurantMenuItemQueryResult ToMenuItemQueryResult(this MenuItem x)
        {
            var result = new RestaurantMenuItemQueryResult
            {
                CategoryId = x.Category.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IngredientIds = x.MenuItemIngredients.Select(ingredient => ingredient.Id).ToArray(),
                Name = x.Name,
                Price = x.Price,
                Unavailable = x.Unavailable,
                MenuItemId = x.Id,
                CategoryName = x.Category.Name
            };

            return result;
        }
    }
}
