using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
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
                Cuisine = cuisine
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
    }
}
