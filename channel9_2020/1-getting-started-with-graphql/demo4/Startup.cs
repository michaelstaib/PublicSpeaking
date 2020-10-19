using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Demo.Data;
using Demo.Types;
using Demo.Types.DataLoader;
using HotChocolate;
using HotChocolate.Data.Filters;


namespace Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPooledDbContextFactory<BookContext>(
                    (s, o) => o
                        .UseSqlite("Data Source=books.db")
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
                .AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .AddType<AuthorType>()
                    .AddType<BookType>()
                    .AddFiltering()
                    .AddSorting()
                    .AddDataLoader<AuthorDataLoader>();;
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
                endpoints.MapGraphQL();
            });
        }
    }
}
