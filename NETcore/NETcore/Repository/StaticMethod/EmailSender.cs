using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NETcore.Repository.StaticMethod
{
    public class EmailSender
    {
        public static void SendEmail(string email, string subject, string htmlMessage)
        {
            string fromMail = "parlinggomanpakpahan16@gmail.com";
            string fromPassword = "201631055";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            smtpClient.Send(message);
        }
    }
}
