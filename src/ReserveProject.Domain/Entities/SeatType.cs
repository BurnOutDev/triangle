using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class SeatType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}