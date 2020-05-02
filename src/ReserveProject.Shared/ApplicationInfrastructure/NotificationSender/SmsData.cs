using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Shared.ApplicationInfrastructure.NotificationSender
{
    public class SmsData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ServiceId { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
        public string SendUrl { get; set; }
        public string Coding { get; set; }
    }

    public class SmsResult
    {
        public bool Success { get; set; }
        public string ResponseText { get; set; }
        public string MessageId { get; set; }

        public SmsResult(bool success, string response)
        {
            Success = success;
            if (success)
                MessageId = response;
            else
                ResponseText = response;
        }
    }

    public class SmsCodes
    {
        public const string Success = "0000";
        public const string InternalError = "0001";
        public const string InvalidRequest = "0003";
        public const string InvalidQuery = "0004";
        public const string EmptyMessage = "0005";
        public const string PrefixError = "0006";
        public const string MSISDNError = "0007";

        // Track codes
        public const string Undefined = "0";
        public const string DeliveredToPhone = "1";
        public const string NotDeliveredToPhone = "2";
        public const string QueuedOnSMSC = "4";
        public const string DeliveredToSMSC = "8";
        public const string NotDeliveredToSMSC = "16";
    }
    public class SmsCodeTexts
    {
        public const string Success = "0000 - Operation successfull";
        public const string InternalError = "0001 - Internal error";
        public const string InvalidRequest = "0003 - Invalid Request";
        public const string InvalidQuery = "0004 - Invalid query";
        public const string EmptyMessage = "0005 - Empty message";
        public const string PrefixError = "0006 - Prefix error";
        public const string MSISDNError = "0007 - MSISDN error";

        // Track codes
        public const string Undefined = "0 - Undefined";
        public const string DeliveredToPhone = "1 - Delivered to phone";
        public const string NotDeliveredToPhone = "2 - Not Delivered to Phone";
        public const string QueuedOnSMSC = "4 - Queued on SMSC";
        public const string DeliveredToSMSC = "8 - Delivered to SMSC";
        public const string NotDeliveredToSMSC = "16 - Not Delivered to SMSC";


    }

}
