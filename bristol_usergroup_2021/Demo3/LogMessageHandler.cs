using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace Demo
{
    public class LogMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine(request.Method + " " + request.RequestUri);

            if (request.Method == HttpMethod.Post)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            Console.WriteLine();

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
