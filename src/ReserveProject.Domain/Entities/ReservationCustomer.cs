using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class ReservationCustomer : BaseEntity
    {
        public virtual Reservation Reservation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}