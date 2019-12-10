using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace StarWarsClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient(
                "StarWarsClient",
                c => c.BaseAddress = new Uri("http://localhost:5000/graphql"));
            serviceCollection.AddStarWarsClient();

            IServiceProvider services = serviceCollection.BuildServiceProvider();
            var client = services.GetRequiredService<IStarWarsClient>();
            var result = await client.GetHeroAsync(Episode.NewHope);
            result.EnsureNoErrors();
            Console.WriteLine(result.Data?.Hero?.Name);
        }
    }
}
