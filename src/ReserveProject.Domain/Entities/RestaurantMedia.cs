using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class RestaurantMedia : BaseEntity
    {
        public int RestaurantId { get; set; }
        public int MediaId { get; set; }
    }
}