using System;

namespace ReserveProject.Shared.Date
{
    public class SystemDate
    {
        public static DateTimeOffset Now
        {
            get
            {
                var date = DateTimeOffset.Now.ToUniversalTime();
                return date;
            }
        }
    }
}