using ReserveProject.Domain;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public ReserveDbContext Context { get; }

        public CustomerService(ReserveDbContext context)
        {
            Context = context;
        }

        public CustomerProfileQueryResult Profile(string userId)
        {
            var customer = CustomerByIdentityUserId(userId);

            var queryResult = new CustomerProfileQueryResult
            {
                Avatar = customer.Avatar,
                BithDate = customer.BithDate,
                Email = customer.Email,
                FacebookId = customer.FacebookId,
                FirstName = customer.FirstName,
                Gender = customer.Gender,
                IsActivated = customer.IsActivated,
                LastName = customer.LastName,
                PhoneNumber = customer.LastName
            };

            return queryResult;
        }

        public CustomerFavoriteRestaurantsQueryResult FavoriteRestaurants(string userId)
        {
            var customer = CustomerByIdentityUserId(userId);
            var restaurants = customer.FavoriteRestaurants
                .Select(_ => _.Restaurant)
                .Select(restaurant => new RestaurantsQueryResult.RestaurantItem
                {
                    Title = restaurant.Name,
                    Cuisine = restaurant.Cuisine.Name,
                    PriceRange = (int)restaurant.PriceRange,
                    Image = restaurant.ImageUrl,
                    Address = restaurant.Address,
                    Rating = $"4.{new Random().Next(0, 9)}",
                    ReviewsCount = new Random().Next(24, 90)
                });
            var queryResult = new CustomerFavoriteRestaurantsQueryResult
            {
                CustomerId = customer.Id,
                Restaurants = restaurants.ToList()
            };

            return queryResult;
        }

        public CustomerReservationsQueryResult Reservations(string userId)
        {
            var customer = CustomerByIdentityUserId(userId);
            var reservations = Context.Set<Reservation>().Where(_ => _.Customer.Id == customer.Id).Select(x => new ReservationsQueryResult.ReservationItem
            {
                CustomerId = x.Customer.Id,
                Comment = x.Comment,
                DateAndTime = x.DateAndTime,
                MenuItems = x.MenuItems.Select(y => new ReservationsQueryResult.ReservationItem.MenuItem
                {
                    MenuItemId = y.MenuItem.Id,
                    Quantity = y.Quantity,
                    Price = y.Price
                }).ToList(),
                PaidAmount = x.PaidAmount,
                Price = x.Price,
                PartySizeChildren = x.PartySizeChildren,
                PartySizeAdults = x.PartySizeAdults,
                PromoId = x.Promo.Id,
                RestaurantId = x.Restaurant.Id,
                SeatTypeId = x.SeatType.Id,
                Status = x.Status.ToString(),
                CustomerName = x.Customer.FullName,
                CustomerPhoneNumber = x.Customer.PhoneNumber,
                PromoName = x.Promo == null ? null : x.Promo.Name,
                SeatType = x.SeatType.Name
            }).ToList();

            var queryResult = new CustomerReservationsQueryResult
            {
                Reservations = reservations,
                CustomerId = customer.Id
            };

            return queryResult;
        }

        private Customer CustomerByIdentityUserId(string userId)
        {
            return Context.Set<Customer>().Where(_ => _.IdentityUserId == userId).FirstOrDefault();
        }
    }
}
