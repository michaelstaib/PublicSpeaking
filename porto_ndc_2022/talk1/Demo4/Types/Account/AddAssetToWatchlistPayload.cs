namespace Demo.Types.Account;

public sealed class AddAssetToWatchlistPayload
{
    private readonly string _addedSymbol;

    public AddAssetToWatchlistPayload(string addedSymbol, Watchlist watchlist)
    {
        _addedSymbol = addedSymbol;
        Watchlist = watchlist;
    }

    public Watchlist? Watchlist { get; }

    public async Task<Asset?> AddedAssetAsync(
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => await assetBySymbol.LoadAsync(_addedSymbol, cancellationToken);
}
