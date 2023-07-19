using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Service.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(MailMessage message)
        {
            string smtpServer = _configuration["MailSettings:SmtpServer"];
            int port = int.Parse(_configuration["MailSettings:Port"]);
            string userName = _configuration["MailSettings:UserName"];
            string password = _configuration["MailSettings:Password"];

            using (var smtpClient = new SmtpClient(smtpServer, port))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(userName, password);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(message);
            }
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
