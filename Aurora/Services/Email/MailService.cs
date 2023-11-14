using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace AuroraAPI.Services.Email
{
    public class MailService :IMailService
    {
        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string emailto, string subject, string body)
        {
            var Mail = new MimeMessage()
            {
                Sender=MailboxAddress.Parse(mailSettings.Email),
                Subject=subject,
            };
            Mail.To.Add(MailboxAddress.Parse(emailto));
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            Mail.Body=builder.ToMessageBody();
            Mail.From.Add(new MailboxAddress(mailSettings.DisplayName,mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Email, mailSettings.Password);
            await smtp.SendAsync(Mail);
            smtp.Disconnect(true);

        }
    }
}
