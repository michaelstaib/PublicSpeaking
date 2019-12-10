using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Stitching;
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

            services.AddQueryRequestInterceptor((context, builder, cancellationToken) =>
            {
                builder.AddProperty("currentUserId", "Q3VzdG9tZXIKZDE=");
                return Task.CompletedTask;
            });

            services.AddStitchedSchema(builder => builder
                .AddSchemaFromHttp("customer")
                .AddSchemaFromHttp("contract")
                .AddExtensionsFromFile("./Extensions.graphql")
                .IgnoreRootTypes()
                .RenameType("LifeInsuranceContract", "LifeInsurance")
                .AddSchemaConfiguration(c =>
                {
                    c.RegisterType<SomeOtherContractExtension>();
                }));
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
