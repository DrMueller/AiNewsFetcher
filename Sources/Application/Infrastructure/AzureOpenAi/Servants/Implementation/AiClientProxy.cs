using Azure.AI.OpenAI;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants.Implementation
{
    public class AiClientProxy : IAiClientProxy
    {
        private readonly AzureOpenAIClient _aiClient;

        public AiClientProxy(AzureOpenAIClient aiClient)
        {
            _aiClient = aiClient;
        }

        public IChatClientProxy GetChatClient(string deploymentName)
        {
           var client = _aiClient.GetChatClient(deploymentName);
            return new ChatClientProxy(client);
        }
    }
    }
