namespace Demo.Types.Account;

public sealed class AddAssetsToWatchlistPayload
{
    private readonly string[] _addedSymbols;

    public AddAssetsToWatchlistPayload(string[] addedSymbols, Watchlist watchlist)
    {
        _addedSymbols = addedSymbols;
        Watchlist = watchlist;
    }

    public Watchlist? Watchlist { get; }

    [UsePaging]
    public async Task<IReadOnlyList<Asset>?> AddedAssetsAsync(
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => await assetBySymbol.LoadAsync(_addedSymbols, cancellationToken)!;
}
