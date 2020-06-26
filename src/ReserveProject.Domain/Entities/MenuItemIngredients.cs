using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class MenuItemIngredients : BaseEntity
    {
        public virtual Ingredient Ingredient { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}