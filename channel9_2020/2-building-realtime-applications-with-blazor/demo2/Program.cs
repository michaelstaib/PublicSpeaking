using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake.Transport.WebSockets;

namespace Client
{
    public class Program
    {
        private static readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNjAzMTEzMjU5LCJleHAiOjE2MDMxNTY0NTksImlhdCI6MTYwMzExMzI1OX0.lvzWRW6273eAf4VGGA4HXJiEtU2cAxnhfWCkQhAzj28";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddHttpClient(
                "ChatClient",
                (services, client) =>
                {
                    client.BaseAddress = new Uri("https://hotchocolate-chat.azurewebsites.net");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("bearer", _token);
                });

            builder.Services.AddWebSocketClient(
                "ChatClient",
                (service, client) => 
                {
                    client.Uri = new Uri("wss://hotchocolate-chat.azurewebsites.net?token=" + _token);
                });

            builder.Services.AddChatClient();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
