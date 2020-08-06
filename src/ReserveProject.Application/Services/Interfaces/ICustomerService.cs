using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;

namespace ReserveProject.Application.Services
{
    public interface ICustomerService
    {
        ReserveDbContext Context { get; }

        CustomerFavoriteRestaurantsQueryResult FavoriteRestaurants(string userId);
        CustomerProfileQueryResult Profile(string userId);
        CustomerReservationsQueryResult Reservations(string userId);
    }
}