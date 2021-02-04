using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class Program
    {
        private const string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNjEyMzg0MzE1LCJleHAiOjE2MTI0Mjc1MTUsImlhdCI6MTYxMjM4NDMxNX0.HekJKxNW84arlARLQfFnrBlWmXbvh4SaxKQXh9N6DH4";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient(
                "ChatClient",
                c => 
                {
                    c.BaseAddress = new Uri("https://hotchocolate-chat.azurewebsites.net");
                    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _token);
                }
            );

            builder.Services.AddChatClient();

            await builder.Build().RunAsync();
        }
    }
}
