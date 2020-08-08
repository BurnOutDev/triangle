using ReserveProject.Domain;
using ReserveProject.Domain.Converters;
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

            var queryResult = customer.ToQueryResult();

            return queryResult;
        }

        public CustomerFavoriteRestaurantsQueryResult FavoriteRestaurants(string userId)
        {
            var customer = CustomerByIdentityUserId(userId);
            var restaurants = customer.FavoriteRestaurants
                .Select(_ => _.Restaurant)
                .Select(restaurant => restaurant.ToQueryResult());
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
            var reservations = Context.Set<Reservation>().Where(_ => _.Customer.Id == customer.Id).Select(x => x.ToQueryResult()).ToList();

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
