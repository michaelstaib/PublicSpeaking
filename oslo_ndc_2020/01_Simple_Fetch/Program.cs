using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient(
                "ChatClient",
                c => 
                {
                    c.BaseAddress = new System.Uri("https://hotchocolate-chat.azurewebsites.net");
                    c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNTkxODYwMTg4LCJleHAiOjE1OTE5MDMzODgsImlhdCI6MTU5MTg2MDE4OH0.2jCZJprPi643c1wixnhAU-Rz1F8HCC3CHD4JVH7pQvg");
                });

            builder.Services.AddChatClient();

            await builder.Build().RunAsync();
        }
    }
}
