using HotChocolate.Execution;

namespace Demo.DataLoader;

public sealed class AlertBySymbolDataLoader : GroupedDataLoader<string, Alert>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;
    private readonly IRequestContextAccessor _contextAccessor;

    public AlertBySymbolDataLoader(
        IDbContextFactory<AssetContext> contextFactory,
        IRequestContextAccessor contextAccessor,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
        _contextAccessor = contextAccessor ??
            throw new ArgumentNullException(nameof(contextAccessor));
    }

    protected override async Task<ILookup<string, Alert>> LoadGroupedBatchAsync(
        IReadOnlyList<string> keys,
        CancellationToken cancellationToken)
    {
        if (_contextAccessor.RequestContext.ContextData.TryGetValue("username", out var value) &&
            value is string username)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var alerts = await context.Alerts.Where(t => keys.Contains(t.Asset!.Symbol) && t.Username == username).Select(t => new { Alert = t, Symbol = t.Asset!.Symbol! }).ToArrayAsync(cancellationToken);
            return alerts.ToLookup(t => t.Symbol, t => t.Alert);
        }

        return Array.Empty<Alert>().ToLookup(t => t.Asset!.Symbol!);
    }
}
