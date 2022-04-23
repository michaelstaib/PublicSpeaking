namespace Demo.Types.Account;

public sealed class RemoveAssetsFromWatchlistPayload
{
    private readonly string[]? _removedSymbols;

    public RemoveAssetsFromWatchlistPayload(string[]? addedSymbols, Watchlist? watchlist)
    {
        _removedSymbols = addedSymbols;
        Watchlist = watchlist;
    }

    public Watchlist? Watchlist { get; }

    [UsePaging]
    public async Task<IReadOnlyList<Asset>?> RemovedAssetsAsync(
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
    {
        if (_removedSymbols is null)
        {
            return null;
        }

        return await assetBySymbol.LoadAsync(_removedSymbols, cancellationToken);
    }
}