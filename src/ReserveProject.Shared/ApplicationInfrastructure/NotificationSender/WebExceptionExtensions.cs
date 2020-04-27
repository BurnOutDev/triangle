using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ReserveProject.Shared.ApplicationInfrastructure.NotificationSender
{
    public static class WebExceptionExtensions
    {
        public static string GetResponseText(this WebException e) =>
            e.Response != null ? ((HttpWebResponse)e.Response).ReadToEnd() : e.ToString();
    }

}
