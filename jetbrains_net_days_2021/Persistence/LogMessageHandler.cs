using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    public class LogMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Network Start ------------------------------------------------------------");
            Console.WriteLine(request.Method + " " + request.RequestUri);

            if (request.Method == HttpMethod.Post)
            {
                Console.WriteLine(await request.Content!.ReadAsStringAsync(cancellationToken));
            }

            Console.WriteLine("Network End   ------------------------------------------------------------");
            Console.WriteLine();

            return await base.SendAsync(request, cancellationToken);
        }
    }
}