using AiNewsFetcher.Infrastructure.Settings;
using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants
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
