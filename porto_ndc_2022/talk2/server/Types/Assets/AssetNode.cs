using Newtonsoft.Json.Serialization;

namespace Demo.Types.Assets;

[Node]
[ExtendObjectType(typeof(Asset))]
public sealed class AssetNode
{
    public async Task<AssetPrice> GetPriceAsync(
        [Parent] Asset asset,
        AssetContext context,
        CancellationToken cancellationToken)
        => await context.AssetPrices.FirstAsync(t => t.Symbol == asset.Symbol, cancellationToken);

    [BindMember(nameof(Asset.ImageKey))]
    public string? GetImageUrl([Parent] Asset asset, [Service] IHttpContextAccessor httpContextAccessor)
    {
        if (asset.ImageKey is null)
        {
            return null;
        }

        string? scheme = httpContextAccessor.HttpContext?.Request.Scheme;
        string? host = httpContextAccessor.HttpContext?.Request.Host.Value;
        if (scheme is null || host is null)
        {
            return null;
        }

        return $"{scheme}://{host}/images/{asset.ImageKey}";
    }

    public async Task<bool?> IsInWatchlistAsync(
        [Parent] Asset asset,
        [GlobalState] string? username,
        WatchlistByUserDataLoader watchListByUser,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            return null;
        }

        HashSet<string>? symbols = await watchListByUser.LoadAsync(username, cancellationToken);

        if (symbols is null)
        {
            return false;
        }

        return symbols.Contains(asset.Symbol!);
    }

    [NodeResolver]
    public static async Task<Asset> GetByIdAsync(
        int id,
        AssetByIdDataLoader assetById,
        CancellationToken cancellationToken)
        => await assetById.LoadAsync(id, cancellationToken);
}
