using System;
using System.Net.Http;
using System.Collections.Generic;
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
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddConferenceClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://hc-conference-app.azurewebsites.net/graphql/"))
                .ConfigureWebSocketClient(client => client.Uri = new Uri("wss://hc-conference-app.azurewebsites.net/graphql/"));

            await builder.Build().RunAsync();
        }
    }
}