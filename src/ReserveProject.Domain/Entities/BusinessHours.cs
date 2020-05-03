using ReserveProject.Domain.Entities.Shared;
using ReserveProject.Domain.Enums;
using System;

namespace ReserveProject.Domain
{
    public class BusinessHours : BaseEntity
    {
        public virtual Restaurant Restaurant { get; set; }
        public WeekDay WeekDay { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}