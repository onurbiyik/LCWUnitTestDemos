using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MsFakesDemo.Tests
{
    internal class MailUtil
    {
        public static void SendMessage(string subject, string body, string to)
        {
            var server = "SMTP.CONTOSO.COM";
            var serverPort = "555";
            var password = "djdjdjdjdjdjdjd";
            var username = "contosotestuser";
            var fromAddress = "info@contoso.com";

            var msg = new MailMessage(new MailAddress(fromAddress, "Contoso Org"),
                                        new MailAddress(to))
            {
                IsBodyHtml = true,
                Priority = MailPriority.High,
                Subject = subject,
                Body = body
            };

            var smtp = new SmtpClient(server);
            if (!string.IsNullOrEmpty(password))
            {
                smtp.Credentials = new NetworkCredential(username, password);
            }

            if (!string.IsNullOrEmpty(serverPort))
            {
                int port;
                if (int.TryParse(serverPort, out port))
                {
                    smtp.Port = port;
                }
            }

            smtp.Send(msg);           
        }
    }
}
