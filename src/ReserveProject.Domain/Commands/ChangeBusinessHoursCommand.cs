using ReserveProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands
{
    public class ChangeBusinessHoursCommand
    {
        public ICollection<WorkDay> WorkDays { get; set; }

        public class WorkDay
        {
            public WeekDay WeekDay { get; set; }
            public TimeSpan OpeningTime { get; set; }
            public TimeSpan ClosingTime { get; set; }
        }
    }
}
