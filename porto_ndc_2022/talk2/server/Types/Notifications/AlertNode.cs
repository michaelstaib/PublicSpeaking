namespace Demo.Types.Notifications;

[Node]
[ExtendObjectType(typeof(Alert))]
public sealed class AlertNode
{
    [BindMember(nameof(Alert.AssetId))]
    public Task<Asset> GetAssetAsync(
        [Parent] Alert notification,
        AssetByIdDataLoader assetById,
        CancellationToken cancellationToken)
        => assetById.LoadAsync(notification.AssetId, cancellationToken);

    [NodeResolver]
    public static Task<Alert?> GetByIdAsync(
        int id,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Alerts.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
}
