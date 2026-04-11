using AiNewsFetcher.Infrastructure.AzureOpenAi;
using AiNewsFetcher.Infrastructure.Emails.Models;
using AiNewsFetcher.Infrastructure.Emails.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace AiNewsFetcher;

public class GetNewsFunction(ILoggerFactory loggerFactory, IAzureOpenAiClient aiClient, IEmailSender emailSender)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<GetNewsFunction>();

    [Function("GetNewsFunction")]
    public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);

        var message = new SystemChatMessage(
            ChatMessageContentPart.CreateTextPart(Prompts.SearchPrompt
            ));

        var searchResult = await aiClient.SendAsync(message);
        await emailSender.SendAsync(new Email(
            "Matthias.mueller@noser.com",
            "AI news",
            searchResult));
    }
}