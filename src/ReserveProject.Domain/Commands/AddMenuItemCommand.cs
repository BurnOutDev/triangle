using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands
{
    public class AddMenuItemCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public string Price { get; set; }
        public string Available { get; set; }
        public int RestaurantId { get; set; }
    }
}
