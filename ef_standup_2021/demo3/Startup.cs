using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Demo.Data;
using HotChocolate;
using HotChocolate.Execution;

namespace Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // DBContext
                .AddDbContext<BookContext>(
                    (s, o) => o
                        .UseSqlite("Data Source=books.db")
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
                
                // GraphQL root types
                .AddScoped<Query>()
                .AddScoped<Mutation>()

                // GraphQL Configuration
                .AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .AddTypeExtension<BookDetails>()
                    .AddProjections()
                    .AddFiltering()
                    .AddSorting()
                    .ModifyOptions(o => o.DefaultResolverStrategy = ExecutionStrategy.Serial);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/");
            });
        }
    }
}
