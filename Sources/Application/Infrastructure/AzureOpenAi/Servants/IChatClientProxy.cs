using System.ClientModel;
using OpenAI.Chat;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants;

public interface IChatClientProxy
{
    Task<ClientResult<ChatCompletion>> CompleteChatAsync(ChatMessage message);
}