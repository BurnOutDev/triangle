using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Converters
{
    public static class ReservationExtensions
    {
        public static ReservationsQueryResult.ReservationItem ToQueryResult(this Reservation entity)
        {
            var result = new ReservationsQueryResult.ReservationItem
            {
                CustomerId = entity.Customer.Id,
                Comment = entity.Comment,
                DateAndTime = entity.DateAndTime,
                MenuItems = entity.MenuItems.Select(y => new ReservationsQueryResult.ReservationItem.MenuItem
                {
                    MenuItemId = y.MenuItem.Id,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    Name = y.MenuItem.Name
                }).ToList(),
                PaidAmount = entity.PaidAmount,
                Price = entity.Price,
                PartySizeChildren = entity.PartySizeChildren,
                PartySizeAdults = entity.PartySizeAdults,
                PromoId = entity.Promo.Id,
                RestaurantId = entity.Restaurant.Id,
                SeatTypeId = entity.SeatType.Id,
                Status = entity.Status.ToString(),
                CustomerName = entity.Customer.FullName,
                CustomerPhoneNumber = entity.Customer.PhoneNumber,
                PromoName = entity.Promo == null ? null : entity.Promo.Name,
                SeatType = entity.SeatType.Name,
                RestaurantImage = entity.Restaurant.ImageUrl,
                ReservationId = entity.Id
            };

            return result;
        }
    }
}
