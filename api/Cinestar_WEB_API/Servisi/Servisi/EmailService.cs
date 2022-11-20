using MailKit.Net.Smtp;
using MimeKit;
using Servisi.IServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Servisi
{
    public class EmailService : IEmailService
    {
        private readonly Modeli.EmailConfiguration.EmailConfig configration;

        public EmailService(Modeli.EmailConfiguration.EmailConfig configration)
        {
            this.configration = configration;
        }

        public async void SendEmail(Modeli.MailModels.Mail mail)
        {
            var emailMessage = CreateEmailMessage(mail);

            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(configration.smtpServer, configration.port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(configration.username, configration.password);
                    client.Send(emailMessage);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.InnerException);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(Modeli.MailModels.Mail mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Dobrodošli "+mail.name, configration.from));
            message.To.Add(mail.To);
            message.Subject = mail.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text=mail.Content};
            return message;
        }
    }
}
