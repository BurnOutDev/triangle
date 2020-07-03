using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;

namespace ReserveProject.Application.Services
{
    public interface IReservationService
    {
        ReserveDbContext Context { get; }

        ReservationsQueryResult GetReservations(string userId);
        void Reserve(ReserveCommand reserveCommand);
    }
}