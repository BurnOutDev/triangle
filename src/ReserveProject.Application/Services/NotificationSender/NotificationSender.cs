using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using ReserveProject.Shared.ApplicationInfrastructure.NotificationSender;

namespace Optimus.Application.Services.NotificationSender
{
    public class NotificationSender : INotificationSender
    {
        private SmtpClient _smtpClient;

        public NotificationSender()
        {
        }

        public void SendMail(EmailData emailData)
        {
            ConstructSmtpClient(emailData.Host, emailData.Port, emailData.UserName, emailData.Password, emailData.UseSSl);

            var message = new MailMessage
            {
                From = new MailAddress(emailData.SenderDisplayName),
                Body = emailData.Body,
                Subject = emailData.Subject
            };

            foreach (string receiver in emailData.Receivers)
                message.To.Add(receiver);

            _smtpClient.Send(message);
        }

        public SmsResult SendSms(SmsData smsData)
        {

            /* Format number */
            if (!string.IsNullOrEmpty(smsData.Receiver))
            {
                var to = smsData.Receiver;

                to = PhoneUtils.CleanPhone(to);

                /* Fix Georgian number without country code */
                to = PhoneUtils.GlobalizePhone(to, 995, 9, 5);

                smsData.Receiver = to;
            }

            var dataUrl = ConustructSmsUrl(smsData.SendUrl, smsData.Username, smsData.Password, smsData.ClientId, smsData.ServiceId, smsData.Receiver, smsData.Text, smsData.Coding);

            var request = (HttpWebRequest)WebRequest.Create(dataUrl);

            string responseText = null;

            try
            {
                using var response = (HttpWebResponse)request.GetResponse();
                string result = response.ReadToEnd();

                if (result != null)
                {
                    var array = result.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                    if (array != null && array.Length > 0)
                    {
                        var code = array[0].Trim();

                        if (code == SmsCodes.Success)
                        {
                            var messageId = array[1].Trim();

                            return new SmsResult(true, messageId);
                        }
                        else
                            responseText = GetTextByCode(code);
                    }
                }
            }
            catch (WebException e)
            {
                responseText = e.GetResponseText();
            }

            return new SmsResult(false, responseText);
        }
        private string GetTextByCode(string code)
        {
            switch (code)
            {
                case SmsCodes.Success:
                    return SmsCodeTexts.Success;
                case SmsCodes.InternalError:
                    return SmsCodeTexts.InternalError;
                case SmsCodes.InvalidRequest:
                    return SmsCodeTexts.InvalidRequest;
                case SmsCodes.InvalidQuery:
                    return SmsCodeTexts.InvalidQuery;
                case SmsCodes.EmptyMessage:
                    return SmsCodeTexts.EmptyMessage;
                case SmsCodes.PrefixError:
                    return SmsCodeTexts.PrefixError;
                case SmsCodes.MSISDNError:
                    return SmsCodeTexts.MSISDNError;
                case SmsCodes.Undefined:
                    return SmsCodeTexts.Undefined;
                case SmsCodes.DeliveredToPhone:
                    return SmsCodeTexts.DeliveredToPhone;
                case SmsCodes.NotDeliveredToPhone:
                    return SmsCodeTexts.NotDeliveredToPhone;
                case SmsCodes.QueuedOnSMSC:
                    return SmsCodeTexts.QueuedOnSMSC;
                case SmsCodes.DeliveredToSMSC:
                    return SmsCodeTexts.DeliveredToSMSC;
                case SmsCodes.NotDeliveredToSMSC:
                    return SmsCodeTexts.NotDeliveredToSMSC;
                default:
                    break;
            }

            return null;
        }

        private string ConustructSmsUrl(string sendUrl, string username, string password, string clientId, string serviceId, string receiver, string text, string coding)
        {
            var url = string.Format("{0}?username={1}&password={2}&client_id={3}&service_id={4}&to={5}&text={6}",
                    sendUrl,
                    WebUtility.UrlEncode(username),
                    WebUtility.UrlEncode(password),
                    WebUtility.UrlEncode(clientId),
                    WebUtility.UrlEncode(serviceId),
                    WebUtility.UrlEncode(receiver),
                    WebUtility.UrlEncode(text));

            if (!string.IsNullOrEmpty(coding))
            {
                url += "&coding=" + WebUtility.UrlEncode(coding);
            }
            return url;
        }

        private void ConstructSmtpClient(string host, int port, string userName, string password, bool useSSl)
        {
            _smtpClient = new SmtpClient(host, port);
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new NetworkCredential(userName, password);
            _smtpClient.EnableSsl = useSSl;

        }
    }
}
