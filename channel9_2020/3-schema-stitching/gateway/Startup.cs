using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Language;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // "/Users/michael/local/PublicSpeaking/channel9_2020/3-schema-stitching/gateway/"

            services.AddHttpClient("accounts", c => c.BaseAddress = new Uri("http://localhost:5051/graphql"));
            services.AddHttpClient("inventory", c => c.BaseAddress = new Uri("http://localhost:5052/graphql"));
            services.AddHttpClient("products", c => c.BaseAddress = new Uri("http://localhost:5053/graphql"));
            services.AddHttpClient("review", c => c.BaseAddress = new Uri("http://localhost:5054/graphql"));

            services
                .AddGraphQLServer()
                .AddRemoteSchema("accounts", ignoreRootTypes: false)
                .AddRemoteSchema("inventory", ignoreRootTypes: false)
                .AddRemoteSchema("products", ignoreRootTypes: false)
                // .AddTypeExtensionsFromString("type Query { }")
                // .AddRemoteSchema("review", ignoreRootTypes: true)
                .AddTypeExtensionsFromFile("../accounts/Stitching.graphql")
                .AddHttpRequestInterceptor((httpContext, executor, builder, ct) =>
                {
                    builder.SetProperty("userId", 1);
                    return default;
                });
                // .AddTypeExtensionsFromFile("../inventory/Stitching.graphql")
                // .AddTypeExtensionsFromFile("../products/Stitching.graphql");
                // .AddTypeExtensionsFromFile("../reviews/Stitching.graphql");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
