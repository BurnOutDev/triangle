using ReserveProject.Domain.Entities.Shared;
using System.Collections.Generic;

namespace ReserveProject.Domain
{
    public class Review : BaseEntity
    {
        public virtual Reservation Reservation { get; set; }
        public string Content { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal Stars { get; set; }
        public virtual ICollection<ReviewMedia> ReviewMedia { get; set; }
    }
}