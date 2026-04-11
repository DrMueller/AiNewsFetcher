using System;
using System.Collections.Generic;
using System.Text;
using AiNewsFetcher.Infrastructure.Settings;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants
{
    public class AiClientProxyFactory : IAiClientProxyFactory
    {
        private readonly IOptions<AppSettings> _appSettings;

        public AiClientProxyFactory(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public IAiClientProxy Create()
        {
            var client = new AzureOpenAIClient(
                new Uri(_appSettings.Value.OpenAiEndpoint),
                new AzureKeyCredential(_appSettings.Value.OpenAiKey)
            );

            return new AiClientProxy(client);
        }
    }
}
