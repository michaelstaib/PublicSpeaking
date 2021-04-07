using System;
using System.Reactive.Linq;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Demo.GraphQL;
using StrawberryShake;
using StrawberryShake.Persistence.SQLite;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var services = CreateServices();

            var client = services.GetRequiredService<IConferenceClient>();

            services.GetRequiredService<SQLitePersistence>().InitializeAsync().Wait();

            client.GetSessions.Watch(ExecutionStrategy.CacheAndNetwork).Select(t => t.Data.Sessions.Nodes).Subscribe(result => 
            {
                foreach(var session in result) 
                {
                    Console.WriteLine(session.Title);
                }
            });

            Console.WriteLine("Hit enter to close!");
            Console.ReadLine();
        }

        private static ServiceProvider CreateServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<LogMessageHandler>()
                .AddConferenceClient()
                .ConfigureHttpClient(
                    c => c.BaseAddress = new Uri("https://hc-conference-app.azurewebsites.net/graphql/"),
                    b => b.AddHttpMessageHandler<LogMessageHandler>())
                .AddSQLitePersistence("Data Source=mydb.db;");

            // configuration goes here ...

            return serviceCollection.BuildServiceProvider();
        }
    }
}
