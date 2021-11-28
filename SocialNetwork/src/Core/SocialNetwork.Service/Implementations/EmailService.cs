using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SocialNetwork.Common.Configurations;
using SocialNetwork.Data.Requests.Email;
using SocialNetwork.Service.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _mailSettings;
        public EmailService(IOptions<EmailSetting> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendAsync(EmailRequest request)
        {
            //create message
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            if (request.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in request.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();

            //send email
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
