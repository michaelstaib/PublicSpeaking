using Demo.Types.Notifications;

namespace Demo.Types.Account;

[ExtendObjectType(typeof(User))]
public sealed class UserNode
{
    [ID]
    [BindMember(nameof(User.Id))]
    public int GetId([Parent] User user) => user.Id;

    public Task<Watchlist?> GetWatchlistAsync(
        [GlobalState] string username,
        AssetContext context,
        CancellationToken cancellationToken)
        => context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

    [UsePaging(ConnectionName = "UserAlert")]
    public IQueryable<Alert>? GetAlerts(
        AssetContext context,
        [GlobalState] string username)
        => context.Alerts.Where(t => t.Username == username).OrderBy(t => t.Asset!.Symbol);

    [UsePaging(IncludeTotalCount = true)]
    public IQueryable<Notification>? GetNotifications(
        AssetContext context,
        [GlobalState] string username,
        ReadStatus status = ReadStatus.All)
        => status switch
        {
            ReadStatus.Read => context.Notifications.Where(t => t.Username == username && t.Read).OrderBy(t => t.Symbol),
            ReadStatus.Unread => context.Notifications.Where(t => t.Username == username && !t.Read).OrderBy(t => t.Symbol),
            _ => context.Notifications.Where(t => t.Username == username).OrderBy(t => t.Symbol),
        };

    [BindMember(nameof(User.ImageKey))]
    public string? GetImageUrl([Parent] User user, [Service] IHttpContextAccessor httpContextAccessor)
    {
        if (user.ImageKey is null)
        {
            return null;
        }

        string? scheme = httpContextAccessor.HttpContext?.Request.Scheme;
        string? host = httpContextAccessor.HttpContext?.Request.Host.Value;
        if (scheme is null || host is null)
        {
            return null;
        }

        return $"{scheme}://{host}/images/{user.ImageKey}";
    }
}
