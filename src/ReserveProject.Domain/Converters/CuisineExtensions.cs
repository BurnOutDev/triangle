using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Converters
{
    public static class CuisineExtensions
    {
        public static CuisinesQueryResult.CuisineItem ToQueryResult(this Cuisine cuisine)
        {
            var result = new CuisinesQueryResult.CuisineItem
            {
                CuisineId = cuisine.Id,
                Title = cuisine.Name,
                RestaurantQuantity = cuisine.Restaurants.Count,
                Image = cuisine.Icon
            };

            return result;
        }
    }
}
