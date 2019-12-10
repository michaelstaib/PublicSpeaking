using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake.Transport.WebSockets;

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
            serviceCollection.AddWebSocketClient(
                "StarWarsClient",
                c => c.Uri = new Uri("ws://localhost:5000/graphql"));
            serviceCollection.AddStarWarsClient();

            IServiceProvider services = serviceCollection.BuildServiceProvider();
            var client = services.GetRequiredService<IStarWarsClient>();
            var result = await client.GetHeroAsync(Episode.NewHope);

            IHasName has = result.Data.Hero;

            result.EnsureNoErrors();
            Console.WriteLine(result.Data.Hero.Name);

            var stream = await client.OnReviewAsync(Episode.NewHope);

            Console.WriteLine("listening...");
            await foreach (var review in stream)
            {
                Console.WriteLine(review.Data.OnReview.Stars);
            }
        }
    }
}
