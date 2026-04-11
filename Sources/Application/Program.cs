using AiNewsFetcher.Infrastructure.AzureOpenAi;
using AiNewsFetcher.Infrastructure.AzureOpenAi.Implementation;
using AiNewsFetcher.Infrastructure.AzureOpenAi.Servants;
using AiNewsFetcher.Infrastructure.Emails.Services;
using AiNewsFetcher.Infrastructure.Emails.Services.Implementation;
using AiNewsFetcher.Infrastructure.Settings;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IAzureOpenAiClient, AzureOpenAiClient>();
builder.Services.AddScoped<IAiClientProxyFactory, AiClientProxyFactory>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Build().Run();