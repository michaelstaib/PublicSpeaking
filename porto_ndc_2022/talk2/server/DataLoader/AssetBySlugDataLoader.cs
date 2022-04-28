using Microsoft.EntityFrameworkCore;
using Demo.Data;

namespace Demo.DataLoader;

public sealed class AssetBySlugDataLoader : BatchDataLoader<string, Asset>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public AssetBySlugDataLoader(
        IDbContextFactory<AssetContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<string, Asset>> LoadBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        return await context.Assets.Where(t => keys.Contains(t.Slug)).ToDictionaryAsync(t => t.Slug!, cancellationToken);
    }
}