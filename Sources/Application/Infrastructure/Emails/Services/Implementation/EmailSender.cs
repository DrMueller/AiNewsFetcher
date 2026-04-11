using System.Net;
using System.Net.Mail;
using AiNewsFetcher.Infrastructure.Emails.Models;
using AiNewsFetcher.Infrastructure.Settings;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace AiNewsFetcher.Infrastructure.Emails.Services.Implementation;

[UsedImplicitly]
public class EmailSender(IOptions<AppSettings> settingsProvider) : IEmailSender
{
    public async Task SendAsync(Email email)
    {
        const string smtpHost = "mail.smtp2go.com";
        const int smtpPort = 587;

        using var message = new MailMessage();
        message.From = new MailAddress("matthiasm@live.de", "Absender");
        message.Subject = email.Subject;
        message.Body = email.HtmlContent;
        message.IsBodyHtml = true;

        message.To.Add(email.ToEmailAddress);

        using var client = new SmtpClient(smtpHost, smtpPort);
        client.Credentials = new NetworkCredential(
            settingsProvider.Value.SmtpUser,
            settingsProvider.Value.SmtpPassword);
        client.EnableSsl = true;

        await client.SendMailAsync(message);
    }
}