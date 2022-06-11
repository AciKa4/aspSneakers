using AspSneakers.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.Emails
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _email;
        private string _password;

        public SmtpEmailSender(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public void Send(EmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_email, _password),
                UseDefaultCredentials = false
            };


            var message = new MailMessage(_email, dto.To);

            message.Subject = dto.Title;
            message.Body = dto.Body;
            message.IsBodyHtml = true;

            smtp.Send(message);
        }
    }
}
