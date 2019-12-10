using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using HotChocolate.Stitching;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Stitching
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup the clients that shall be used to access the remote endpoints.
            services.AddHttpClient("customer", (sp, client) =>
            {
                // in order to pass on the token or any other headers to the backend schema use the IHttpContextAccessor
                HttpContext context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                client.BaseAddress = new Uri("http://127.0.0.1:5050");
            });

            services.AddHttpClient("contract", (sp, client) =>
            {
                // in order to pass on the token or any other headers to the backend schema use the IHttpContextAccessor
                HttpContext context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                client.BaseAddress = new Uri("http://127.0.0.1:5051");
            });

            services.AddHttpContextAccessor();

            services.AddQueryRequestInterceptor((context, builder, ct) => 
            {
                builder.AddProperty("userId", "Q3VzdG9tZXIKZDI=");
                return Task.CompletedTask;
            });

            services.AddStitchedSchema(builder => 
            {
                builder.AddSchemaFromHttp("contract")
                    .AddSchemaFromHttp("customer")
                    .AddExtensionsFromFile("./Extensions.graphql")
                    .RenameType("LifeInsuranceContract", "LifeInsurance")
                    .IgnoreRootTypes();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL(new QueryMiddlewareOptions { EnableSubscriptions = false });
            app.UsePlayground();
        }
    }
}
