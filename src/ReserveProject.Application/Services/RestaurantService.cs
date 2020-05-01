using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class RestaurantService
    {
        public ReserveDbContext Context { get; }

        public RestaurantService(ReserveDbContext context)
        {
            Context = context;
        }

        public void AddRestaurant(AddRestaurantCommand addRestaurantCommand)
        {
            var restaurant = Restaurant.Create(addRestaurantCommand.Name, addRestaurantCommand.Description, addRestaurantCommand.PhoneNumber, addRestaurantCommand.WebsiteUrl, addRestaurantCommand.Email, addRestaurantCommand.BusinessId, addRestaurantCommand.FacebookId, addRestaurantCommand.CuisineId, addRestaurantCommand.PriceRange, addRestaurantCommand.HasParking, addRestaurantCommand.IsCardPaymentAvailable);

            Context.Add(restaurant);
        }

        public void ChangeBusinessHours(ChangeBusinessHoursCommand businessHours)
        {
            
        }
    }
}
