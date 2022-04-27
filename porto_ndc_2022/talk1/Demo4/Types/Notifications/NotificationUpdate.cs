namespace Demo.Types.Notifications;

public sealed class NotificationUpdate
{
    private readonly int? _notificationId;

    public NotificationUpdate()
    {
        _notificationId = null;
    }

    public NotificationUpdate(int? notificationId)
    {
        _notificationId = notificationId;
    }

    public async Task<Notification?> GetNotificationAsync(
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (_notificationId is null)
        {
            return null;
        }

        return await context.Notifications.FirstOrDefaultAsync(t => t.Id == _notificationId, cancellationToken);
    }

    public Task<int> GetUnreadNotificationsAsync(
        [GlobalState] string username,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Notifications.Where(t => t.Username == username && !t.Read).CountAsync(cancellationToken);
}