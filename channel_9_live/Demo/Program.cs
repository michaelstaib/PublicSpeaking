using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Program
    {
        private const string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1pY2hhZWxAY2hpbGxpY3JlYW0uY29tIiwiZW1haWwiOiJtaWNoYWVsQGNoaWxsaWNyZWFtLmNvbSIsIkNoYXQuVXNlcklkIjoiODA4YTE1MGYtNDliOC00MjFhLTgxNGEtZmRkMjlmMzYxZTg2IiwibmJmIjoxNjEzNjY2OTI2LCJleHAiOjE2MTM3MTAxMjYsImlhdCI6MTYxMzY2NjkyNn0.Q6ak7Wr_QFfq4Kg1SKYh_mIXrTz6MrBG6c_YrHCDRP4";
        
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
                });

            builder.Services.AddWebSocketClient(
                "ChatClient",
                c =>
                {
                    c.Uri = new Uri("wss://hotchocolate-chat.azurewebsites.net?token=" + _token);
                });

            builder.Services.AddChatClient();

            await builder.Build().RunAsync();
        }
    }
}
