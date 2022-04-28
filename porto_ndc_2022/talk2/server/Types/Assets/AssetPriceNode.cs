using System.Text.Json;
using Demo.Data;
using Demo.DataLoader;

namespace Demo.Types.Assets;

[Node]
[ExtendObjectType(typeof(AssetPrice), IgnoreProperties = new[] { nameof(AssetPrice.AssetId) })]
public sealed class AssetPriceNode
{
    [GraphQLType(typeof(AssetPriceChangeType))]
    public async Task<JsonElement> GetChangeAsync(
        ChangeSpan span,
        [ScopedState("span")] SetState<ChangeSpan> setSpan,
        [Parent] AssetPrice parent,
        AssetPriceChangeDataLoader assetPriceBySymbol,
        CancellationToken cancellationToken)
    {
        setSpan(span);
        return await assetPriceBySymbol.LoadAsync(new KeyAndSpan(parent.Symbol!, span), cancellationToken);
    }

    [GraphQLType(typeof(AssetPriceChangeType))]
    public async Task<JsonElement> GetChangeAsync(
        ChangeSpan span,
        [ScopedState("span")] SetState<ChangeSpan> setSpan,
        [Parent] AssetPrice parent,
        [Service] IHttpClientFactory clientFactory,
        CancellationToken cancellationToken)
    {
        setSpan(span);

        using var client = clientFactory.CreateClient(Constants.PriceInfoService);
        using var request = new HttpRequestMessage(HttpMethod.Get, $"api/asset/price/change/v2?symbols={parent.Symbol}&span={span}");
        using var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        var document = JsonDocument.Parse(content);
        return document.RootElement.EnumerateArray().First();
    }

    [NodeResolver]
    public static Task<AssetPrice> GetByIdAsync(
        int id,
        AssetPriceByIdDataLoader dataLoader,
        CancellationToken cancellationToken)
        => dataLoader.LoadAsync(id, cancellationToken);
}