using System.Text.Json;
using Demo.Types.Assets;

namespace Demo.DataLoader;

public sealed class AssetImportDataLoader : BatchDataLoader<string, Asset>
{
    private readonly IHttpClientFactory _clientFactory;

    public AssetImportDataLoader(
        IHttpClientFactory clientFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
    }

    protected override async Task<IReadOnlyDictionary<string, Asset>> LoadBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        using var client = _clientFactory.CreateClient(Constants.PriceInfoService);
        using var assetRequest = new HttpRequestMessage(HttpMethod.Get, $"api/asset?symbols={string.Join(",", keys)}");
        using var priceRequest = new HttpRequestMessage(HttpMethod.Get, $"api/asset/price?symbols={string.Join(",", keys)}");
        using var priceChangeRequest = new HttpRequestMessage(HttpMethod.Get, $"api/asset/price/change?symbols={string.Join(",", keys)}&span={ChangeSpan.Day}");

        using var assetResponse = await client.SendAsync(assetRequest, cancellationToken);
        assetResponse.EnsureSuccessStatusCode();

        using var priceResponse = await client.SendAsync(priceRequest, cancellationToken);
        priceResponse.EnsureSuccessStatusCode();

        using var priceChangeResponse = await client.SendAsync(priceChangeRequest, cancellationToken);
        priceChangeResponse.EnsureSuccessStatusCode();

        var map = new Dictionary<string, Asset>();
        var content = await assetResponse.Content.ReadAsByteArrayAsync(cancellationToken);
        var assets = JsonDocument.Parse(content).RootElement;
        content = await priceResponse.Content.ReadAsByteArrayAsync(cancellationToken);
        var prices = JsonDocument.Parse(content).RootElement;
        content = await priceChangeResponse.Content.ReadAsByteArrayAsync(cancellationToken);
        var priceChanges = JsonDocument.Parse(content).RootElement;

        var priceLookup = new Dictionary<string, JsonElement>();
        foreach (JsonElement price in prices.EnumerateArray())
        {
            priceLookup[price.GetProperty("symbol").GetString()!] = price;
        }

        var priceChangeLookup = new Dictionary<string, JsonElement>();
        foreach (JsonElement price in priceChanges.EnumerateArray())
        {
            priceChangeLookup[price.GetProperty("symbol").GetString()!] = price;
        }


        foreach (JsonElement assetInfo in assets.EnumerateArray())
        {
            string symbol = assetInfo.GetProperty("symbol").GetString()!;

            var asset = new Asset
            {
                Symbol = symbol,
                Name = assetInfo.GetProperty("name").GetString(),
                Slug = assetInfo.GetProperty("slug").GetString(),
                Description = assetInfo.GetProperty("description").GetString(),
                Color = assetInfo.GetProperty("color").GetString(),
                ImageKey = assetInfo.GetProperty("imageUrl").GetString(),
                Website = assetInfo.GetProperty("website").GetString(),
                WhitePaper = assetInfo.GetProperty("whitePaper").GetString(),
            };

            map.Add(symbol, asset);
        }

        return map;
    }
}
