using System.Text.Json;
using Demo.Types.Assets;

namespace Demo.DataLoader;

public sealed class AssetPriceHistoryDataLoader : HttpBatchDataLoader<KeyAndSpan>
{
    public AssetPriceHistoryDataLoader(
        IHttpClientFactory clientFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(clientFactory, batchScheduler, options)
    {
    }

    protected override async Task<IReadOnlyDictionary<KeyAndSpan, JsonElement>> LoadBatchAsync(
        IReadOnlyList<KeyAndSpan> keys,
        HttpClient client,
        CancellationToken cancellationToken)
    {
        var map = new Dictionary<KeyAndSpan, JsonElement>();

        foreach (var group in keys.GroupBy(t => t.Span))
        {
            string symbols = string.Join(",", group.Select(t => t.Symbol));
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"api/asset/price/history?symbols={symbols}&span={group.Key}");
            using var response = await client.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
            var document = JsonDocument.Parse(content);
            var root = document.RootElement;

            foreach (JsonElement priceInfo in root.EnumerateArray())
            {
                string symbol = priceInfo.GetProperty("symbol").GetString()!;
                map.Add(new(symbol, group.Key), priceInfo);
            }
        }

        return map;
    }
}
