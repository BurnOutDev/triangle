using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands
{
    public partial class ChangeBusinessHoursCommand
    {
        public int RestaurantId { get; set; }

        public ICollection<WorkDay> BusinessHours { get; set; }
    }
}
