namespace AiNewsFetcher.Infrastructure.AzureOpenAi.Servants
{
    public interface IAiClientProxyFactory
    {
        IAiClientProxy Create();
    }
}
