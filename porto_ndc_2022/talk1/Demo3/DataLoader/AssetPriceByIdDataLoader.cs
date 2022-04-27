namespace Demo.DataLoader;

public sealed class AssetPriceByIdDataLoader : BatchDataLoader<int, AssetPrice>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public AssetPriceByIdDataLoader(
        IDbContextFactory<AssetContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, AssetPrice>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.AssetPrices.Where(t => keys.Contains(t.Id)).ToDictionaryAsync(t => t.Id!, cancellationToken);
    }
}
