using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReserveProject.Shared.ApplicationInfrastructure.NotificationSender
{
    public class PhoneUtils
    {
        private static readonly Regex DigitsOnly = new Regex(@"[^\d]");

        public static string CleanPhone(string phone)
            => phone == null ? null : DigitsOnly.Replace(phone, "");

        public static string GlobalizePhone(string phone, int countryCode, int numberLength /* Without country code */, int prefix)
        {
            if (phone.Length == numberLength
                && phone.StartsWith(prefix.ToString()))
            {
                phone = countryCode.ToString() + phone;
            }

            return phone;
        }
    }
}
