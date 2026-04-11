namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants;

public interface IAiClientProxy
{
    IChatClientProxy GetChatClient(string deploymentName);
}