using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Seggu.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient smtpClient;

        public EmailService()
        {
            this.smtpClient = new SmtpClient();
            this.smtpClient.Host = Properties.Settings.Default.SmtpServerHost;
            this.smtpClient.Port = Properties.Settings.Default.SmtpServerPort;
            this.smtpClient.UseDefaultCredentials = false;
            this.smtpClient.EnableSsl = Properties.Settings.Default.UseSsl;
            this.smtpClient.Credentials = new NetworkCredential("info@seggu.com.ar", "seggu2016");
            this.smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void Send(MailMessage eMailMessage)
        {
            eMailMessage.From = new MailAddress(Properties.Settings.Default.SmtpAddressFrom);
            this.smtpClient.Send(eMailMessage);
        }

        public async Task SendAsync(MailMessage eMailMessage)
        {
            await this.smtpClient.SendMailAsync(eMailMessage);
        }
    }
}
