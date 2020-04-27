using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Shared.ApplicationInfrastructure.NotificationSender
{
    public class EmailData
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderDisplayName { get; set; }
        public IEnumerable<string> Receivers { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
