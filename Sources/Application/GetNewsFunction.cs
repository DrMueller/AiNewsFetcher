using AiNewsFetcher.Infrastructure.AzureOpenAi;
using AiNewsFetcher.Infrastructure.Emails.Models;
using AiNewsFetcher.Infrastructure.Emails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace AiNewsFetcher;

public class GetNewsFunction
{
    private readonly IAzureOpenAiClient _aiClient;
    private readonly IEmailSender _emailSender;
    private readonly ILogger _logger;

    public GetNewsFunction(ILoggerFactory loggerFactory, IAzureOpenAiClient aiClient, IEmailSender emailSender)
    {
        _aiClient = aiClient;
        _emailSender = emailSender;
        _logger = loggerFactory.CreateLogger<GetNewsFunction>();
    }

    [Function("TestTimer")]
    public async Task<IActionResult> RunManual(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        await Run(null); // Timer-Methode manuell aufrufen
        return new OkResult();
    }

    [Function("GetNewsFunction")]
    public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);

        var message = new SystemChatMessage(
            ChatMessageContentPart.CreateTextPart(Prompts.SearchPrompt
            ));

        var searchResult = await _aiClient.SendAsync(message);
        await _emailSender.SendAsync(new Email(
            "Matthias.mueller@noser.com",
            "AI news",
            searchResult));
    }
}