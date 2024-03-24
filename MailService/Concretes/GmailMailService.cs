using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace MailService.Concretes
{
    public class GmailMailService : IMailService
    {
        private readonly SMTPConfig smtpConfig;
        private SmtpClient smtpClient;

        public GmailMailService(IOptions<SMTPConfig> config)
        {
            smtpConfig = config.Value;
            smtpClient = CreateSMTPClient();
        }
        private SmtpClient CreateSMTPClient()
        {
            smtpClient = new SmtpClient(smtpConfig.Host);
            smtpClient.Port = smtpClient.Port;
            smtpClient.Credentials = new NetworkCredential(smtpConfig.OwnerMail, smtpConfig.OwnerPassword);
            smtpClient.EnableSsl = true;

            return smtpClient;
        }

        public void Send(string title, string body, List<string> tos, List<string> ccs)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpConfig.OwnerMail);
            mail.Subject = title;
            mail.Body = body;
            mail.IsBodyHtml = true;
            tos.ForEach(t =>
            {
                mail.To.Add(new MailAddress(t));
            });

            if(ccs is not null)
            ccs.ForEach(c =>
            {
                mail.CC.Add(new MailAddress(c));
            });
            smtpClient.Send(mail);
        }
    }
}
