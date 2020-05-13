using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using HotChocolate.Types;


namespace Subscriptions
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemorySubscriptions();

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType(c => c.Name("Query").Field("some").Resolver("value"))
                    .AddMutationType<Mutation>()
                    .AddSubscriptionType<Subscription>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseWebSockets();

            app.UseGraphQL();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }

    public class Mutation
    {
        public async Task<string> WriteMessage(string message, [Service]ITopicEventSender eventSender)
        {
            await eventSender.SendAsync("MESSAGES", message);

            return message;
        }
    }

    public class Subscription
    {
        [Subscribe(nameof(OnMessage))]
        public async ValueTask<IAsyncEnumerable<string>> OnMessageSubscribe(
            [Service]ITopicEventReceiver eventReceiver)
        {
            return await eventReceiver.SubscribeAsync<string, string>("MESSAGES");
        }

        public string OnMessage([EventMessage]string message) => message;
    }
}
