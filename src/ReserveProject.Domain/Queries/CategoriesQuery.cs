using System.Collections.Generic;

namespace ReserveProject.Domain.Queries
{
    public class CategoriesQueryResult
    {
        public ICollection<CategoryItem> Categories { get; set; }

        public class CategoryItem
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
        }
    }
}
