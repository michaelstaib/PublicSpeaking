using HotChocolate.Subscriptions;

namespace Demo.Types.Notifications;

[ExtendObjectType(OperationTypeNames.Subscription)]
public sealed class NotificationSubscriptions
{
    [Subscribe(With = nameof(CreateOnNotificationUpdateStream))]
    public NotificationUpdate OnNotification(
        [EventMessage] NotificationUpdate message)
        => message;

    public IAsyncEnumerable<NotificationUpdate> CreateOnNotificationUpdateStream(
        [GlobalState] string username,
        [Service] ITopicEventReceiver receiver,
        [Service] IDbContextFactory<AssetContext> contextFactory)
        => new OnNotificationUpdateStream(username, receiver, contextFactory);

    private sealed class OnNotificationUpdateStream : IAsyncEnumerable<NotificationUpdate>
    {
        private readonly string _username;
        private readonly ITopicEventReceiver _receiver;
        private readonly IDbContextFactory<AssetContext> _contextFactory;

        public OnNotificationUpdateStream(
            string username,
            ITopicEventReceiver receiver,
            IDbContextFactory<AssetContext> contextFactory)
        {
            _username = username;
            _receiver = receiver;
            _contextFactory = contextFactory;
        }

        public async IAsyncEnumerator<NotificationUpdate> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            if (_username is null)
            {
                throw new GraphQLException("You need to be signed in for this subscription!");
            }

            await using (AssetContext context = await _contextFactory.CreateDbContextAsync(cancellationToken))
            {
                if (await context.Notifications.AnyAsync(t => t.Username == _username, cancellationToken))
                {
                    yield return new();
                }
            }

            var stream = await _receiver.SubscribeAsync<string, NotificationUpdate>(
                Constants.OnNotification(_username),
                cancellationToken);

            await foreach (NotificationUpdate message in 
                stream.ReadEventsAsync().WithCancellation(cancellationToken))
            {
                yield return message;
            }
        }
    }
}
