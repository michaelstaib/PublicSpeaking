using System;
using Microsoft.Extensions.DependencyInjection;

namespace Demo
{
    public static class Setup
    {
        private static void ConfigureServices(this ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<LogMessageHandler>()
                .AddConferenceClient()
                .ConfigureInMemoryClient()
                .ConfigureHttpClient(
                    client => client.BaseAddress = new Uri("https://hc-conference-app.azurewebsites.net/graphql/"),
                    builder => builder.AddHttpMessageHandler<LogMessageHandler>());
        }

        public static IServiceProvider CreateServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
