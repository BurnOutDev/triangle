using System;
using ReserveProject.Shared.Date;

namespace ReserveProject.Shared.Logging
{
    public class GeneralLog
    {
        public GeneralLog()
        {
        }

        public GeneralLog(string name, GeneralLogType generalLogType, string serializedMetadata, string exception,
            string userId)
        {
            Name = name;
            GeneralLogType = generalLogType;
            SerializedMetadata = serializedMetadata;
            Exception = exception;
            UserId = userId;
            Date = SystemDate.Now;
        }

        public int Id { get; set; }
        public GeneralLogType GeneralLogType { get; }
        public string Name { get; set; }
        public string Exception { get; }
        public string UserId { get; }
        public DateTimeOffset Date { get; }
        public string SerializedMetadata { get; set; }
    }
}