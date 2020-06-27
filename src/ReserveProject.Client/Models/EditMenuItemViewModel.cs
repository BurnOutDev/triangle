using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Domain.Queries;

namespace ReserveProject.Client.Models
{
    public class EditMenuItemViewModel
    {
        public IngredientsQueryResult IngredientsQuery { get; set; }
        public KeyValuesQueryResult CategoriesQuery { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool Unavailable { get; set; }
        public int[] IngredientIds { get; set; }

        [FromForm]
        public IFormFile FormImage { get; set; }
    }
}
