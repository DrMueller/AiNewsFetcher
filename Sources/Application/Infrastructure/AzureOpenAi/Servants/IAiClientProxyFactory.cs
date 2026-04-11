using System;
using System.Collections.Generic;
using System.Text;

namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants
{
    public interface IAiClientProxyFactory
    {
        IAiClientProxy Create();
    }
}
