using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;
using System;
using System.Linq;

namespace ReserveProject.Application.Services
{
    public class ReservationService : IReservationService
    {
        public ReserveDbContext Context { get; }

        public ReservationService(ReserveDbContext context)
        {
            Context = context;
        }

        public void Reserve(ReserveCommand reserveCommand)
        {
            var restaurant = Context.Find<Restaurant>(reserveCommand.RestaurantId);
            var customer = Context.Find<Customer>(reserveCommand.CustomerId);
            var seatType = Context.Find<SeatType>(reserveCommand.SeatTypeId);

            var discount = Context.Set<Promo>().Where(promo => promo.Code == reserveCommand.PromoCode).FirstOrDefault();

            var reservation = new Reservation
            {
                Customer = customer,
                Comment = reserveCommand.Comment,
                DateAndTime = reserveCommand.DateAndTime,
                PaidAmount = 0,
                PartySize = reserveCommand.PartySize,
                Promo = discount,
                Status = PaymentStatus.NotPaid,
                Restaurant = restaurant,
                SeatType = seatType
            };

            var selectedMenuItemIds = reserveCommand.MenuItems.Select(item => item.MenuItemId);

            var restaurantMenuItems = Context.Set<MenuItem>().Where(item => selectedMenuItemIds.Contains(item.Id));

            var unavailable = restaurantMenuItems.Any(item => item.Unavailable);

            if (unavailable)
                throw new Exception("Error, menu item is not available!");

            var menuItemsCalculated = reserveCommand.MenuItems.Select(item =>
            {
                var menuItem = Context.Find<MenuItem>(item.MenuItemId);

                return new ReservationMenuItem
                {
                    MenuItem = menuItem,
                    Price = menuItem.Price,
                    Quantity = item.Quantity,
                    Reservation = reservation
                };
            });

            Context.Add(reservation);
            Context.AddRange(menuItemsCalculated);

            Context.SaveChanges();
        }

        public ReservationsQueryResult GetReservations(string userId)
        {
            var restaurant = GetRestaurantByUserId(userId);

            var reservations = Context.Set<Reservation>().Where(x => x.Restaurant.Id == restaurant.Id)
                .Select(x => new ReservationsQueryResult.ReservationItem
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
                    PartySize = x.PartySize,
                    PromoId = x.Promo.Id,
                    RestaurantId = x.Restaurant.Id,
                    SeatTypeId = x.SeatType.Id,
                    Status = x.Status.ToString(),
                    CustomerName = x.Customer.FullName,
                    CustomerPhoneNumber = x.Customer.PhoneNumber,
                    PromoName = x.Promo == null ? null : x.Promo.Name,
                    SeatType = x.SeatType.Name
                }).ToList();

            var queryResult = new ReservationsQueryResult
            {
                RestaurantId = restaurant.Id,
                Reservations = reservations
            };

            return queryResult;
        }

        private Restaurant GetRestaurantByUserId(string userId)
        {
            return Context.Set<IdentityUserRestaurant>().Where(user => user.IdentityUserId == userId).FirstOrDefault().Restaurant;
        }
    }
}
