using ReserveProject.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Entities
{
    public class CustomerFavoriteRestaurants : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
