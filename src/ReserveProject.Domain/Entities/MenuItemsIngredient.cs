using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class MenuItemsIngredient : BaseEntity
    {
        public virtual Ingredient Ingredient { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}