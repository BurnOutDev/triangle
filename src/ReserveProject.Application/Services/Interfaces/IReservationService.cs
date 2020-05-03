using ReserveProject.Persistence;

namespace ReserveProject.Application.Services
{
    public interface IReservationService
    {
        ReserveDbContext Context { get; }
    }
}