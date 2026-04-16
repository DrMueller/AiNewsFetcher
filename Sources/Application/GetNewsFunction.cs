using AiNewsFetcher.Infrastructure.AzureOpenAi;
using AiNewsFetcher.Infrastructure.Emails.Models;
using AiNewsFetcher.Infrastructure.Emails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace AiNewsFetcher;

public class GetNewsFunction(ILoggerFactory loggerFactory, IAzureOpenAiClient aiClient, IEmailSender emailSender)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<GetNewsFunction>();


    [Function("TestGetNewsFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }

    [Function("GetNewsFunction")]
    public async Task Run([TimerTrigger("0 0 23 * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);
        await RunInternalAsync()
    }

    private async Task RunInternalAsync()
    {
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