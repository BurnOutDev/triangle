using ReserveProject.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Entities
{
    public class MobileAppSettings : BaseEntity
    {
        public string Language { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
