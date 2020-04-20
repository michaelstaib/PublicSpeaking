using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Chat.Server.Messages
{
    [ExtendObjectType(Name = "Subscription")]
    public class MessageSubscriptions
    {
        [Subscribe]
        public async Task<IAsyncEnumerable<Message>> OnMessageReceivedAsync(
            [GlobalState]string currentUserEmail,
            [Service]IEventTopicObserver eventTopicObserver,
            CancellationToken cancellationToken)
        {
            return await eventTopicObserver.SubscribeAsync<string, Message>(
                currentUserEmail, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
