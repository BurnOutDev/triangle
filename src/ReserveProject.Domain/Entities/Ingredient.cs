using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAllergen { get; set; }
    }
}