using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class ReservationMenuItem : BaseEntity
    {
        public virtual Reservation Reservation { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}