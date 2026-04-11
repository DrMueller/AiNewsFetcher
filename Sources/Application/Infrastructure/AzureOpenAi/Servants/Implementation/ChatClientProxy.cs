using System.ClientModel;
using OpenAI.Chat;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants;

public class ChatClientProxy : IChatClientProxy
{
    private readonly ChatClient _chatClient;

    public ChatClientProxy(ChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<ClientResult<ChatCompletion> > CompleteChatAsync(ChatMessage message)
    {
        return await _chatClient.CompleteChatAsync(message);
    }
}