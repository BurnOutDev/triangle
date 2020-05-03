using ReserveProject.Domain.Enums;

namespace ReserveProject.Domain.Commands
{
    public class WorkDay
    {
        public WeekDay WeekDay { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
