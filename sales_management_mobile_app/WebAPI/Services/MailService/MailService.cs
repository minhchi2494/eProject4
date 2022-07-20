using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Settings;

namespace WebAPI.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly LoginService _loginService;
        public MailService(IOptions<MailSettings> mailSettings, LoginService loginService)
        {
            _mailSettings = mailSettings.Value;
            _loginService = loginService;
        }

        public async Task sendPasswordViaEmail(MailRequest request)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[username]", request.UserName).Replace("[newPassword]", _loginService.generatePassword(request.UserName));
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = $"[Administrator] Sales Management System Recover password";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
