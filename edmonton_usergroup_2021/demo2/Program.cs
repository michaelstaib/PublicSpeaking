using System;
using Microsoft.Extensions.DependencyInjection;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var services = CreateServices();


            Console.WriteLine("Hit enter to close!");
            Console.ReadLine();
        }

        private static ServiceProvider CreateServices()
        {
            var serviceCollection = new ServiceCollection();

            // configuration goes here ...

            return serviceCollection.BuildServiceProvider();
        }
    }
}
