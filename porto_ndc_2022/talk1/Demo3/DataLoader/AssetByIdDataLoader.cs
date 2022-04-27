namespace Demo.DataLoader;

public sealed class AssetByIdDataLoader : BatchDataLoader<int, Asset>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public AssetByIdDataLoader(
        IDbContextFactory<AssetContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Asset>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Assets.Where(t => keys.Contains(t.Id)).ToDictionaryAsync(t => t.Id!, cancellationToken);
    }
}
