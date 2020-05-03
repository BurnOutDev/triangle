using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Review : BaseEntity
    {
        public virtual Reservation Reservation { get; set; }
        public string Content { get; set; }
        public virtual Customer Customer { get; set; }
        public int Stars { get; set; }
    }
}