using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;
using ReserveProject.Persistence;

namespace ReserveProject.Application.Services
{
    public interface IReservationService
    {
        ReserveDbContext Context { get; }

        AddReviewCommandResult AddReview(string userId, AddReviewCommand addReviewCommand);
        ReservationsQueryResult Reservations();
        ReserveCommandResult Reserve(string userId, ReserveCommand reserveCommand);
    }
}