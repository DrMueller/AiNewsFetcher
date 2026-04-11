using System.Text;
using AiNewsFetcher.Infrastructure.AzureOpenAi.Servants;
using AiNewsFetcher.Infrastructure.Settings;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Implementation
{
    [UsedImplicitly]
    public class AzureOpenAiClient(IOptions<AppSettings> settings, IAiClientProxyFactory proxyFactory) : IAzureOpenAiClient
    {
        public async Task<string> SendAsync(ChatMessage message)
        {
            var chatClient = CreateChatClient();

            var response = await chatClient.CompleteChatAsync(message);
            var result = response.Value.Content.Aggregate(new StringBuilder(), (sb, msg) => sb.AppendLine(msg.Text)).ToString();
            result = result.Replace("```", string.Empty);

            return result;
        }

        private IChatClientProxy CreateChatClient()
        {
            var clientProxy = proxyFactory.Create();
            var chatClient = clientProxy.GetChatClient(settings.Value.OpenAiDeploymentName);

            return chatClient;
        }
    }
}