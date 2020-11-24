using System;
using System.Linq;
using ContosoUni.Data;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoUni
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContextFactory<SchoolContext>(
                    (services, options) =>
                    {
                        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                        options.UseLoggerFactory(loggerFactory);
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        private static void InitializeDatabase(IApplicationBuilder app)
        {
            var contextFactory = app.ApplicationServices.GetRequiredService<IDbContextFactory<SchoolContext>>();
            using var context = contextFactory.CreateDbContext();

            if (context.Database.EnsureCreated())
            {
                var course = new Course { Credits = 10, Title = "Object Oriented Programming 1" };

                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student { FirstMidName = "Rafael", LastName = "Foo", EnrollmentDate = DateTime.UtcNow }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student { FirstMidName = "Pascal", LastName = "Bar", EnrollmentDate = DateTime.UtcNow }
                });
                context.Enrollments.Add(new Enrollment
                {
                    Course = course,
                    Student = new Student { FirstMidName = "Michael", LastName = "Baz", EnrollmentDate = DateTime.UtcNow }
                });
                context.SaveChangesAsync();
            }
        }
    }
}
