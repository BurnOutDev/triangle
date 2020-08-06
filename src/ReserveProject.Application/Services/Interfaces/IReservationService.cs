using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;

namespace ReserveProject.Application.Services
{
    public interface IReservationService
    {
        ReserveDbContext Context { get; }

        ReservationsQueryResult Reservations();
        void Reserve(string userId, ReserveCommand reserveCommand);
    }
}