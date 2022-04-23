namespace Demo.Types.Notifications;

[Node]
[ExtendObjectType(typeof(Notification))]
public sealed class NotificationNode
{
    [BindMember(nameof(Notification.Symbol))]
    public Task<Asset> GetAssetAsync(
        [Parent] Notification notification,
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => assetBySymbol.LoadAsync(notification.Symbol!, cancellationToken);

    [NodeResolver]
    public static Task<Notification?> GetByIdAsync(
        int id,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Notifications.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
}
