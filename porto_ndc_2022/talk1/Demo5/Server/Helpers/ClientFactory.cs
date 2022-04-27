using System.Security.Claims;
using System.Text.Json;
using HotChocolate.Subscriptions;

namespace Demo.Helpers;

public sealed partial class AssetPriceChangeProcessor : IHostedService, IDisposable
{
    private static HttpClient CreateClient()
    {
        return new HttpClient();
    }
}
