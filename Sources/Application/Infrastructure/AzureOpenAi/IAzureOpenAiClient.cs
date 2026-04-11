using OpenAI.Chat;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi
{
    public interface IAzureOpenAiClient
    {
        Task<string> SendAsync(ChatMessage message);
    }
}
