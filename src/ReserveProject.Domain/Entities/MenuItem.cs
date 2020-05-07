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
        public decimal Price { get; set; }
        public bool Unavailable { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}