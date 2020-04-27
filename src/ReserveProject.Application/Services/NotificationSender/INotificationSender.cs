using ReserveProject.Shared.ApplicationInfrastructure.NotificationSender;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optimus.Application.Services.NotificationSender
{
    public interface INotificationSender
    {
        void SendMail(EmailData emailData);
        SmsResult SendSms(SmsData smsData);
    }
}
