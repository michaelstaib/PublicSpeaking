using System;
using Microsoft.Extensions.DependencyInjection;
using Demo.GraphQL;
using Demo.GraphQL.State;
using System.Threading.Tasks;
using StrawberryShake;
using StrawberryShake.Persistence.SQLite;
using System.Reactive.Linq;
using System.Linq;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Yield();

            var services = Setup.CreateServices();
            var client = services.GetRequiredService<IConferenceClient>();

            using var storeSession =
                client
                    .GetSessions
                    .Watch()
                    .Where(result => result.IsSuccessResult())
                    .SelectMany(result => result.Data.Sessions.Nodes)
                    .Subscribe(session => Console.WriteLine($"{session.Id} - {session.Title}"));

            Console.ReadLine();
        }
    }
}
