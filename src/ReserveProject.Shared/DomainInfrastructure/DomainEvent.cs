using System;

namespace ReserveProject.Shared.DomainInfrastructure
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public int AggregateRootId { get; set; }
        public Guid UId { get; set; }
        public DateTimeOffset OccuredOn { get; set; }
        public string EventType { get; set; }
        public int? StreamId { get; set; }

        public virtual string EntityName()
        {
            return "";
        }

        public virtual string ActionName()
        {
            return GetType().Name.Replace("Event", "");
        }
    }
}