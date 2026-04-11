using AiNewsFetcher.Infrastructure.Emails.Models;

namespace AiNewsFetcher.Infrastructure.Emails.Services;

public interface IEmailSender
{
    Task SendAsync(Email email);
}