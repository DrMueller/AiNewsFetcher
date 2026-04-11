namespace AiNewsFetcher.Infrastructure.Emails.Models;

public record Email(string ToEmailAddress, string Subject, string HtmlContent);