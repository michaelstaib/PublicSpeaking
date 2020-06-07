using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake.Transport.WebSockets;

namespace Client
{
    public class Program
    {
        private static readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNTgyOTA1MjUzLCJleHAiOjE1ODI5NDg0NTMsImlhdCI6MTU4MjkwNTI1M30.9-_slvR8bwnWjtbxAMg7vZuU9gRT68TEvQosV293SC4";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddHttpClient(
                "ChatClient",
                (services, client) =>
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("bearer", _token);
                });
            builder.Services.AddWebSocketClient(
                "ChatClient",
                (service, client) => 
                {
                    client.Uri = new Uri("ws://localhost:5000?token=" + _token);
                });
            builder.Services.AddChatClient();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
