namespace AiNewsFetcher.Infrastructure.Settings;

public class AppSettings
{
    public string OpenAiDeploymentName { get; set; } = null!;
    public string OpenAiEndpoint { get; set; } = null!;
    public string OpenAiKey { get; set; } = null!;
    public string SmtpUser { get; set; } = null!;
    public string SmtpPassword { get; set; } = null!;
}