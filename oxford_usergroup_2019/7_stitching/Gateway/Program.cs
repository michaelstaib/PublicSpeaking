using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Demo.Stitching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://localhost:5055")
                .UseStartup<Startup>();
    }
}
