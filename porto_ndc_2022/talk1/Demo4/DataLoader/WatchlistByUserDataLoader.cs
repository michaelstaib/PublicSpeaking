namespace Demo.DataLoader;

public sealed class WatchlistByUserDataLoader : CacheDataLoader<string, HashSet<string>?>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public WatchlistByUserDataLoader(
        IDbContextFactory<AssetContext> contextFactory,
        DataLoaderOptions? options = null)
        : base(options)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<HashSet<string>?> LoadSingleAsync(
        string key,
        CancellationToken cancellationToken)
    {
        await using AssetContext context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == key, cancellationToken: cancellationToken);

        if (watchlist is null)
        {
            return null;
        }

        return watchlist.GetSymbols().ToHashSet();
    }
}
