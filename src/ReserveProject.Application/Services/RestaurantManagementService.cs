using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class RestaurantManagementService : IRestaurantManagementService
    {
        public ReserveDbContext Context { get; }

        public RestaurantManagementService(ReserveDbContext context)
        {
            Context = context;
        }

        public void AddRestaurant(AddRestaurantCommand addRestaurantCommand)
        {
            var cuisine = Context.Find<Cuisine>(addRestaurantCommand.CuisineId);

            var restaurant = new Restaurant
            {
                Name = addRestaurantCommand.Name,
                Description = addRestaurantCommand.Description,
                PhoneNumber = addRestaurantCommand.PhoneNumber,
                WebsiteUrl = addRestaurantCommand.WebsiteUrl,
                Email = addRestaurantCommand.Email,
                BusinessId = addRestaurantCommand.BusinessId,
                FacebookId = addRestaurantCommand.FacebookId,
                HasParking = addRestaurantCommand.HasParking,
                IsCardPaymentAvailable = addRestaurantCommand.IsCardPaymentAvailable,
                PriceRange = addRestaurantCommand.PriceRange,
                Cuisine = cuisine,
                Address = addRestaurantCommand.Address,
                AddressLatitude = addRestaurantCommand.AddressLatitude,
                AddressLongtitude = addRestaurantCommand.AddressLongtitude,
                ImageUrl = addRestaurantCommand.Image
            };

            restaurant.BusinessHours = addRestaurantCommand.BusinessHours?.Select(workday => new BusinessHours
            {
                Restaurant = restaurant,
                WeekDay = workday.WeekDay,
                OpeningTime = TimeSpan.Parse(workday.OpeningTime),
                ClosingTime = TimeSpan.Parse(workday.ClosingTime)
            }).ToList();

            Context.Add(restaurant);
            Context.SaveChanges();
        }

        public void ChangeBusinessHours(ChangeBusinessHoursCommand businessHoursCommand)
        {
            var restaurant = Context.Find<Restaurant>(businessHoursCommand.RestaurantId);
            var businessHours = Context.Set<BusinessHours>().Where(businessHour => businessHour.Restaurant.Id == businessHoursCommand.RestaurantId);

            Context.Set<BusinessHours>().RemoveRange(businessHours);

            Context.AddRange(businessHoursCommand.BusinessHours.Select(workday => new BusinessHours
            {
                Restaurant = restaurant,
                WeekDay = workday.WeekDay,
                OpeningTime = TimeSpan.Parse(workday.OpeningTime),
                ClosingTime = TimeSpan.Parse(workday.ClosingTime)
            }).ToList());

            Context.Update(restaurant);
            Context.SaveChanges();
        }

        public void UpdateRestaurant(string userId, UpdateRestaurantCommand updateRestaurantCommand)
        {
            var restaurant = GetRestaurantByUserId(userId);

            restaurant.Name = updateRestaurantCommand.Name;
            restaurant.Description = updateRestaurantCommand.Description;
            restaurant.PhoneNumber = updateRestaurantCommand.PhoneNumber;
            restaurant.WebsiteUrl = updateRestaurantCommand.WebsiteUrl;
            restaurant.Email = updateRestaurantCommand.Email;

            restaurant.FacebookId = updateRestaurantCommand.FacebookId;

            restaurant.ImageUrl = updateRestaurantCommand.ImageUrl;

            restaurant.Address = updateRestaurantCommand.Address;
            restaurant.AddressLatitude = updateRestaurantCommand.AddressLatitude;
            restaurant.AddressLongtitude = updateRestaurantCommand.AddressLongtitude;

            restaurant.CuisineId = updateRestaurantCommand.CuisineId;
            restaurant.PriceRange = updateRestaurantCommand.PriceRange;

            restaurant.HasParking = updateRestaurantCommand.HasParking;
            restaurant.IsCardPaymentAvailable = updateRestaurantCommand.IsCardPaymentAvailable;

            Context.Update(restaurant);
            Context.SaveChanges();
        }

        public void AddMenuItem(AddMenuItemCommand addMenuItemCommand)
        {
            var category = Context.Find<Category>(addMenuItemCommand.CategoryId);
            var ingredient = Context.Find<Ingredient>(addMenuItemCommand.IngredientId);
            var restaurant = Context.Find<Restaurant>(addMenuItemCommand.RestaurantId);

            var menuItem = new MenuItem
            {
                Name = addMenuItemCommand.Name,
                Description = addMenuItemCommand.Description,
                ImageUrl = addMenuItemCommand.ImageUrl,
                Category = category,
                Ingredient = ingredient,
                Restaurant = restaurant,
                Price = addMenuItemCommand.Price
            };

            Context.Add(menuItem);
            Context.SaveChanges();
        }

        public void AddIngredient(AddIngredientCommand addIngredientCommand)
        {
            var ingredient = new Ingredient
            {
                Name = addIngredientCommand.Name,
                IsAllergen = addIngredientCommand.IsAllergen,
                IsVegan = addIngredientCommand.IsVegan,
                IsVegetarian = addIngredientCommand.IsVegetarian
            };

            Context.Add(ingredient);
            Context.SaveChanges();
        }

        public void AddCategory(AddCategoryCommand addCategoryCommand)
        {
            var category = new Category
            {
                Name = addCategoryCommand.Name,
                Icon = addCategoryCommand.Icon
            };

            Context.Add(category);
            Context.SaveChanges();
        }

        public void AddCuisine(AddCuisineCommand addCuisineCommand)
        {
            var cuisine = new Cuisine
            {
                Name = addCuisineCommand.Name,
                Icon = addCuisineCommand.Icon
            };

            Context.Add(cuisine);
            Context.SaveChanges();
        }

        public RestaurantsPerCategoryQueryResult RestaurantsPerCategory(RestaurantsPerCategoryQuery restaurantsPerCategoryQuery)
        {
            var restaurants = Context.Set<Restaurant>().Select(restaurant => new RestaurantsPerCategoryQueryResult.RestaurantItem
            {
                Title = restaurant.Name,
                Cuisine = restaurant.Cuisine.Name,
                PriceRange = (int)restaurant.PriceRange,
                Image = restaurant.ImageUrl,
                Address = restaurant.Address,
                Rating = $"4.{new Random().Next(0, 9)}",
                ReviewsCount = new Random().Next(24, 90)
            });

            var queryResult = new RestaurantsPerCategoryQueryResult
            {
                CategoryName = restaurantsPerCategoryQuery.CategoryName,
                Restaurants = restaurants.ToList()
            };

            //Image = restaurant.Media
            //                .Where(x => x.Format == MediaFormat.Picture)
            //                .Select(x => x.Url)
            //                .FirstOrDefault(),

            return queryResult;
        }

        public CuisinesQueryResult Cuisines()
        {
            var cuisines = Context.Set<Cuisine>().Select(cuisine => new CuisinesQueryResult.CuisineItem
            {
                CuisineId = cuisine.Id,
                Title = cuisine.Name,
                RestaurantQuantity = cuisine.Restaurants.Count,
                Image = cuisine.Icon
            });

            var queryResult = new CuisinesQueryResult
            {
                Cuisines = cuisines.ToList()
            };

            return queryResult;
        }

        public RestaurantProfileQueryResult RestaurantProfile(string userId)
        {
            var restaurant = GetRestaurantByUserId(userId);

            var queryResult = new RestaurantProfileQueryResult
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

            return queryResult;
        }

        private Restaurant GetRestaurantByUserId(string userId)
        {
            return Context.Set<IdentityUserRestaurant>().Where(user => user.IdentityUserId == userId).FirstOrDefault().Restaurant;
        }
    }
}
