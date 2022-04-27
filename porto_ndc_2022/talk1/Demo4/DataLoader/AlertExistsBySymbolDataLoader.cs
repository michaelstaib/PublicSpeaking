using HotChocolate.Execution;

namespace Demo.DataLoader;

public sealed class AlertExistsBySymbolDataLoader : BatchDataLoader<string, bool>
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;
    private readonly IRequestContextAccessor _contextAccessor;

    public AlertExistsBySymbolDataLoader(
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

    protected override async Task<IReadOnlyDictionary<string, bool>> LoadBatchAsync(
        IReadOnlyList<string> keys, 
        CancellationToken cancellationToken)
    {
        if (_contextAccessor.RequestContext.ContextData.TryGetValue("username", out var value) &&
            value is string username)
        {
            await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var alerts = await context.Assets.Where(t => keys.Contains(t.Symbol) && t.Alerts.Any(t => t.Username == username)).Select(t => new { t.Symbol, HasAlerts = t.Alerts.Any() }).ToArrayAsync(cancellationToken: cancellationToken);
            return alerts.ToDictionary(t => t.Symbol!, t => t.HasAlerts);
        }

        return keys.ToDictionary(t => t, _ => false);
    }
}
