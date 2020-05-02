using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ReserveProject.Shared.ApplicationInfrastructure.NotificationSender
{
    public static class HttpWebResponseExtensions
    {
        public static string ReadToEnd(this HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
