using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public string Price { get; set; }
        public string Available { get; set; }
        public int RestaurantId { get; set; }
    }
}