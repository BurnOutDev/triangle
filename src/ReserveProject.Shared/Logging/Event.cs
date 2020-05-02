using System;
using ReserveProject.Shared.Date;

namespace ReserveProject.Shared.Logging
{
    public class Event
    {
        public Event()
        {

        }

        public Event(string type, string data, Guid entityId, string remoteIp)
        {
            Type = type;
            Data = data;
            CreateDate = SystemDate.Now;
            EntityId = entityId;
            RemoteIp = remoteIp;
        }

        public int Id { get; set; }

        public string Type { get; private set; }

        public string Data { get; private set; }

        public Guid EntityId { get; private set; }

        public DateTimeOffset CreateDate { get; private set; }

        public string RemoteIp { get; private set; }

        public bool ProcessedByJob { get; private set; }


        public void MarkAsProcessed()
        {
            ProcessedByJob = true;
        }

        public bool Processed()
        {
            return ProcessedByJob == true;
        }
    }
}
