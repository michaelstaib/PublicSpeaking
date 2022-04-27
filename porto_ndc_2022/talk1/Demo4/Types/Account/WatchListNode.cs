namespace Demo.Types.Account;

[Node]
[ExtendObjectType(typeof(Watchlist))]
public sealed class WatchlistNode
{
    [BindMember(nameof(Watchlist.User))]
    public Task<User> GetUserAsync(
        [Parent] Watchlist watchlist,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Users.FirstAsync(t => t.Name == watchlist.User, cancellationToken);

    [UsePaging]
    [BindMember(nameof(Watchlist.SymbolsData))]
    public async Task<IEnumerable<Asset>> GetAssetsAsync(
        [Parent] Watchlist watchlist,
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => await assetBySymbol.LoadAsync(watchlist.GetSymbols(), cancellationToken);

    [NodeResolver]
    public static Task<Watchlist?> GetById(
        int id,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Watchlists.FirstOrDefaultAsync(
            a => a.Id == id && a.User == username,
            cancellationToken);
}