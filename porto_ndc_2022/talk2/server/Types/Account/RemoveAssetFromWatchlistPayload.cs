namespace Demo.Types.Account;

public sealed class RemoveAssetFromWatchlistPayload
{
    private readonly string? _removedSymbol;

    public RemoveAssetFromWatchlistPayload(string? removedSymbol, Watchlist? watchlist)
    {
        _removedSymbol = removedSymbol;
        Watchlist = watchlist;
    }

    public Watchlist? Watchlist { get; }

    public async Task<Asset?> RemovedAssetAsync(
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
    {
        if (_removedSymbol is null)
        {
            return null;
        }

        return await assetBySymbol.LoadAsync(_removedSymbol, cancellationToken);
    }
}
