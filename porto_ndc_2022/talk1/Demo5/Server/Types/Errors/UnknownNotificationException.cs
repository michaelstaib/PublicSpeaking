#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class UnknownNotificationException : Exception
{
    public UnknownNotificationException(int notificationId)
        : this(new[] { notificationId })
    { }

    public UnknownNotificationException(IReadOnlyCollection<int> notificationIds)
        : base("The specified notification ids are not valid for the current user.")
    {
        NotificationIds = notificationIds;
    }

    public IReadOnlyCollection<int> NotificationIds { get; }
}