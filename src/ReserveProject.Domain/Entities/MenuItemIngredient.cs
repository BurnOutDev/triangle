using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class MenuItemIngredient : BaseEntity
    {
        public virtual MenuItem MenuItem { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}