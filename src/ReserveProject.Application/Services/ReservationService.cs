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

        public ReserveCommandResult Reserve(string userId, ReserveCommand reserveCommand)
        {
            var restaurant = Context.Find<Restaurant>(reserveCommand.RestaurantId);
            var customer = Context.Set<Customer>().Where(_ => _.IdentityUserId == userId).FirstOrDefault();
            var seatType = Context.Find<SeatType>(reserveCommand.SeatTypeId);

            var discount = Context.Set<Promo>().Where(promo => promo.Code == reserveCommand.PromoCode).FirstOrDefault();

            var reservation = new Reservation
            {
                Customer = customer,
                Comment = reserveCommand.Comment,
                DateAndTime = reserveCommand.DateAndTime,
                PaidAmount = 0,
                PartySizeAdults = reserveCommand.PartySizeAdults,
                PartySizeChildren = reserveCommand.PartySizeChildren,
                Promo = discount,
                Status = PaymentStatus.NotPaid,
                Restaurant = restaurant,
                SeatType = seatType,
            };

            var selectedMenuItemIds = reserveCommand.MenuItems.Select(item => item.MenuItemId);

            var restaurantMenuItems = Context.Set<MenuItem>().Where(item => selectedMenuItemIds.Contains(item.Id));

            var unavailable = restaurantMenuItems.Any(item => item.Unavailable);

            if (unavailable)
                throw new Exception("Error, menu item is not available!");

            var menuItemsCalculated = reserveCommand.MenuItems
                .Where(x => x.Quantity > 0)
                .Select(item =>
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

            reservation.Price = menuItemsCalculated.Sum(p => p.Price);

            Context.Add(reservation);
            Context.AddRange(menuItemsCalculated);

            Context.SaveChanges();

            return new ReserveCommandResult
            {
                IsError = false
            };
        }

        public ReservationsQueryResult Reservations()
        {
            var reservations = Context.Set<Reservation>()
                .Select(x => new ReservationsQueryResult.ReservationItem
                {
                    CustomerId = x.Customer.Id,
                    Comment = x.Comment,
                    DateAndTime = x.DateAndTime,
                    MenuItems = x.MenuItems.Select(y => new ReservationsQueryResult.ReservationItem.MenuItem
                    {
                        MenuItemId = y.MenuItem.Id,
                        Quantity = y.Quantity,
                        Price = y.Price,
                        Name = y.MenuItem.Name
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
                    SeatType = x.SeatType.Name,
                    RestaurantImage = x.Restaurant.ImageUrl,
                    ReservationId = x.Id
                }).ToList();

            var queryResult = new ReservationsQueryResult
            {
                Reservations = reservations
            };

            return queryResult;
        }

        public AddReviewCommandResult AddReview(string userId, AddReviewCommand addReviewCommand)
        {
            var customer = Context.Set<Customer>().Where(c => c.IdentityUserId == userId).FirstOrDefault();
            var reservation = Context.Find<Reservation>(addReviewCommand.ReservationId);

            var review = new Review
            {
                Content = addReviewCommand.Content,
                Customer = customer,
                Reservation = reservation,
                Stars = addReviewCommand.Stars
            };

            var entityCollection = addReviewCommand.MediaItems?.Select(i => new ReviewMedia
            {
                Review = review,
                Media = new Media
                {
                    Format = Enum.Parse<MediaFormat>(i.Format),
                    Url = i.Base64
                }
            });

            Context.Add(review);
            Context.AddRange(entityCollection);
            Context.SaveChanges();

            return new AddReviewCommandResult
            {
                IsError = false
            };
        }
    }
}
