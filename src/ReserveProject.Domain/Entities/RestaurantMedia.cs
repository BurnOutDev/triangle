using ReserveProject.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain
{
    public class RestaurantMedia : BaseEntity
    {
        public virtual Restaurant Restaurant { get; set; }
        public virtual Media Media { get; set; }
    }
}
