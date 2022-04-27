using Demo.Data;
using Demo.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace Demo.Types.Assets;

[Node]
[ExtendObjectType(typeof(Asset))]
public sealed class AssetNode
{
    public async Task<AssetPrice> GetPriceAsync(
        [Parent] Asset asset,
        AssetPriceBySymbolDataLoader priceBySymbol,
        CancellationToken cancellationToken)
        => await priceBySymbol.LoadAsync(asset.Symbol!, cancellationToken);

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

    public Task<bool> HasAlertsAsync(
        [Parent] Asset asset,
        AlertExistsBySymbolDataLoader alertExistsBySymbol,
        CancellationToken cancellationToken)
        => alertExistsBySymbol.LoadAsync(asset.Symbol!, cancellationToken);

    [UsePaging(IncludeTotalCount = true, ConnectionName = "AssetAlerts")]
    public Task<Alert[]> GetAlerts(
        [Parent] Asset asset,
        AlertBySymbolDataLoader alertBySymbol,
        CancellationToken cancellationToken) 
        => alertBySymbol.LoadAsync(asset.Symbol!, cancellationToken);

    [NodeResolver]
    public static Task<Asset?> GetById(int id, AssetContext context)
        => context.Assets.FirstOrDefaultAsync(a => a.Id == id);
}
