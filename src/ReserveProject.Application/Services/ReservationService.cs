using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Enums;
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
            Context.Add(menuItemsCalculated);

            Context.SaveChanges();
        }
    }
}
