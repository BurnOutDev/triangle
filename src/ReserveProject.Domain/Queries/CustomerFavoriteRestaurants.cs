using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class CustomerFavoriteRestaurantsQueryResult : RestaurantsQueryResult
    {
        public int CustomerId { get; set; }
    }
}
