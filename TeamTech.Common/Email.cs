using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace TeamTech.Common
{
    public class Email : IDisposable
    {
        private SmtpClient _client;
        private bool _useSsl;
        public MailMessage Message { get; set; }

        private Email()
        {
            Message = new MailMessage();
            _client = new SmtpClient();
        }

        public Email Attach(IList<Attachment> attachments)
        {
            foreach (Attachment attachment in from attachment in attachments
                                              where !Message.Attachments.Contains(attachment)
                                              select attachment)
            {
                Message.Attachments.Add(attachment);
            }
            return this;
        }

        public Email Attach(Attachment attachment)
        {
            if (!Message.Attachments.Contains(attachment))
            {
                Message.Attachments.Add(attachment);
            }
            return this;
        }

        public Email BlindCarbonCopy(string emailAddress, string name = "")
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                if (emailAddress.Contains(";"))
                {
                    foreach (string str in emailAddress.Split(';'))
                    {
                        Message.Bcc.Add(new MailAddress(str, name));
                    }
                }
                else
                {
                    Message.Bcc.Add(new MailAddress(emailAddress, name));
                }
            }
            return this;
        }

        public Email Body(string body, bool isHtml = true)
        {
            Message.Body = body;
            Message.IsBodyHtml = isHtml;
            return this;
        }

        public Email Cancel()
        {
            _client.SendAsyncCancel();
            return this;
        }

        public Email CarbonCopy(string emailAddress, string name = "")
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                if (emailAddress.Contains(";"))
                {
                    foreach (string str in emailAddress.Split(';'))
                    {
                        Message.CC.Add(new MailAddress(str, name));
                    }
                }
                else
                {
                    Message.CC.Add(new MailAddress(emailAddress, name));
                }
            }
            return this;
        }

        public static Email From(string emailAddress, string name = "")
        {
            return new Email { Message = { From = new MailAddress(emailAddress, name) } };
        }

        public static Email FromDefault()
        {
            return new Email { Message = new MailMessage() };
        }

        public Email HighPriority()
        {
            Message.Priority = MailPriority.High;
            return this;
        }

        public Email LowPriority()
        {
            Message.Priority = MailPriority.Low;
            return this;
        }

        public Email ReplyTo(string address)
        {
            Message.ReplyToList.Add(new MailAddress(address));
            return this;
        }

        public Email ReplyTo(string address, string name)
        {
            Message.ReplyToList.Add(new MailAddress(address, name));
            return this;
        }

        public Email Send()
        {
            _client.EnableSsl = _useSsl;
            _client.Send(Message);
            return this;
        }

        public Email SendAsync(SendCompletedEventHandler callback, object token = null)
        {
            _client.EnableSsl = _useSsl;
            _client.SendCompleted += callback;
            _client.SendAsync(Message, token);
            return this;
        }

        public Email Subject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        public Email To(IList<MailAddress> mailAddresses)
        {
            foreach (MailAddress address in mailAddresses)
            {
                Message.To.Add(address);
            }
            return this;
        }

        public Email To(string emailAddress)
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                if (emailAddress.Contains(";"))
                {
                    foreach (string str in emailAddress.Split(';'))
                    {
                        Message.To.Add(new MailAddress(str));
                    }
                }
                else
                {
                    Message.To.Add(new MailAddress(emailAddress));
                }
            }

            return this;
        }

        public Email To(string emailAddress, string name)
        {
            if (emailAddress.Contains(";"))
            {
                string[] strArray = name.Split(';');
                string[] strArray2 = emailAddress.Split(';');
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string displayName = string.Empty;
                    if ((strArray.Length - 1) >= i)
                    {
                        displayName = strArray[i];
                    }
                    Message.To.Add(new MailAddress(strArray2[i], displayName));
                }
            }
            else
            {
                Message.To.Add(new MailAddress(emailAddress, name));
            }
            return this;
        }

        public Email UseSsl()
        {
            _useSsl = true;
            return this;
        }

        public Email UsingClient(SmtpClient client)
        {
            _client = client;
            return this;
        }

        public Email UsingStringTemplateText(string contenido, bool isHtml = true)
        {
            Message.Body = contenido;
            Message.IsBodyHtml = isHtml;
            return this;
        }

        public Email AlternateView(AlternateView alternativeView, bool isHtml = true)
        {
            Message.AlternateViews.Add(alternativeView);
            Message.IsBodyHtml = isHtml;
            return this;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
