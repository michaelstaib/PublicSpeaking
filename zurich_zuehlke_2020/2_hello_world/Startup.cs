using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<Query>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL();
        }

        public class Query
        {
            public Greetings Hello() => new Greetings();
        }

        public class Greetings
        {
            public string Hello() => "world";
        }
    }
}
