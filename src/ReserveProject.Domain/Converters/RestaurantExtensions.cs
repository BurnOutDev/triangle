using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Converters
{
    public static class RestaurantExtensions
    {
        public static RestaurantsQueryResult.RestaurantItem ToQueryResult(this Restaurant restaurant)
        {
            var result = new RestaurantsQueryResult.RestaurantItem
            {
                Title = restaurant.Name,
                Cuisine = restaurant.Cuisine.Name,
                PriceRange = (int)restaurant.PriceRange,
                Image = restaurant.ImageUrl,
                Address = restaurant.Address,
                Rating = $"4.{new Random().Next(0, 9)}",
                ReviewsCount = new Random().Next(24, 90),
                RestaurantId = restaurant.Id
            };

            return result;
        }

        public static RestaurantProfileQueryResult ToProfileQueryResult(this Restaurant restaurant)
        {
            var result = new RestaurantProfileQueryResult
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                Address = restaurant.Address,
                AddressLatitude = restaurant.AddressLatitude,
                AddressLongtitude = restaurant.AddressLongtitude,
                BusinessId = restaurant.BusinessId,
                Email = restaurant.Email,
                FacebookId = restaurant.FacebookId,
                HasParking = restaurant.HasParking,
                ImageUrl = restaurant.ImageUrl,
                IsCardPaymentAvailable = restaurant.IsCardPaymentAvailable,
                PhoneNumber = restaurant.PhoneNumber,
                PriceRange = (int)restaurant.PriceRange,
                WebsiteUrl = restaurant.WebsiteUrl,
                CuisineId = restaurant.Cuisine.Id
            };

            return result;
        }

        public static RestaurantQueryResult ToRestaurantQueryResult(this Restaurant restaurant)
        {
            var result = new RestaurantQueryResult
            {
                RestaurantId = restaurant.Id,
                Address = restaurant.Address,
                Cuisine = restaurant.Cuisine.Name,
                Image = restaurant.ImageUrl,
                PriceRange = (int)restaurant.PriceRange,
                Rating = "5.3",
                Title = restaurant.Name,
                Description = restaurant.Description,
                ReviewsCount = 98,
                AddressLatitude = restaurant.AddressLatitude,
                AddressLongtitude = restaurant.AddressLongtitude,
                Website = restaurant.WebsiteUrl
            };

            return result;
        }
    }
}
