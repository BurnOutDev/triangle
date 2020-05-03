using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands.Shared
{
    public class Ingredient
    {
        public string Name { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAllergen { get; set; }
    }
}
