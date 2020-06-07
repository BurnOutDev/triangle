using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class IngredientsQueryResult
    {
        public ICollection<IngredientItem> Ingredients { get; set; }

        public class IngredientItem
        {
            public int IngredientId { get; set; }
            public string Name { get; set; }
            public bool IsVegan { get; set; }
            public bool IsVegetarian { get; set; }
            public bool IsAllergen { get; set; }
        }
    }
}
