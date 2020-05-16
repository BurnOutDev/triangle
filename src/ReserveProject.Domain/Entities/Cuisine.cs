using ReserveProject.Domain.Entities.Shared;
using System.Collections.Generic;

namespace ReserveProject.Domain
{
    public class Cuisine : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
