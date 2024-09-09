using MimeKit;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;

using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using UserManagmentService.Models;

namespace UserManagmentService.Services
{
    public class EmailService : IEmailServices
    {
        private readonly EmailConfiguration _emailconfig;
        public EmailService(EmailConfiguration configuration)
        {
            this._emailconfig = configuration;
        }


        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailconfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return emailMessage;
        }
        public void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailconfig.SmtpServer, _emailconfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailconfig.UserName, _emailconfig.Password);
                client.Send(mailMessage);
            }
            catch (Exception)
            { 

                throw;
            }
            finally
            {
                client.Dispose();
                client.Dispose();
            }
        }
    }
}
