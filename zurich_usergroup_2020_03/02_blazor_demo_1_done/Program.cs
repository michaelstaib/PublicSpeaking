using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddBlazoredSessionStorage();
            
            builder.Services.AddChatClient();
            builder.Services.AddHttpClient(
                "ChatClient",
                client => 
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    client.DefaultRequestHeaders.Authorization = 
                        new AuthenticationHeaderValue("bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNTgyNzE3MDI5LCJleHAiOjE1ODI3NjAyMjksImlhdCI6MTU4MjcxNzAyOX0.beTKSooYKp0iZ-iSsnWVPRvXBANsfBtns71yStKhYLY");
                });

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
