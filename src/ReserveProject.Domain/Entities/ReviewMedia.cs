using ReserveProject.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain
{
    public class ReviewMedia : BaseEntity
    {
        public virtual Review Review { get; set; }
        public virtual Media Media { get; set; }
    }
}
