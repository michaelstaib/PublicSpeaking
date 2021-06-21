using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using StrawberryShake;
using StrawberryShake.Persistence.SQLite;
using System.Reactive.Linq;
using Demo.State;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<LogMessageHandler>()
                .AddConferenceClient()
                .ConfigureHttpClient(
                    c => c.BaseAddress = new Uri("https://hc-conference-app.azurewebsites.net/graphql/"),
                    b => b.AddHttpMessageHandler<LogMessageHandler>())
                .AddSQLitePersistence("Data Source=mydb.db;");

            IServiceProvider services = serviceCollection.BuildServiceProvider();
            SQLitePersistence persistence = services.GetRequiredService<SQLitePersistence>();
            IConferenceClient client = services.GetRequiredService<IConferenceClient>();

            // 1) fill store with persisted data.
            await persistence.InitializeAsync();
            
            // 2) watch store for updates
            using var storeSession =
                client
                    .GetSessions
                    .Watch(ExecutionStrategy.CacheAndNetwork)
                    .Where(r => r.IsSuccessResult())
                    .SelectMany(r => r.Data!.Sessions!.Nodes)
                    .Subscribe(session => Console.WriteLine($"{session.Id} - {session.Title}"));

            Console.ReadLine();
            
            var result = await client.UpdateSessionTitle.ExecuteAsync("U2Vzc2lvbgppMzU=", "Abc 123");

            Console.ReadLine();
        }
    }
}
