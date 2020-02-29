using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Chat.Server.People
{
    [ExtendObjectType(Name = "Subscription")]
    public class PersonSubscriptions
    {
        [Subscribe]
        public async Task<IAsyncEnumerable<Person>> OnOnlineAsync(
            [Service]IEventTopicObserver eventTopicObserver,
            CancellationToken cancellationToken) =>
            await eventTopicObserver.SubscribeAsync<string, Person>(
                "online", cancellationToken)
                .ConfigureAwait(false);

        [Subscribe]
        public async Task<IAsyncEnumerable<Person>> OnTypingAsync(
            [Service]IEventTopicObserver eventTopicObserver,
            [GlobalState]string currentUserEmail,
            CancellationToken cancellationToken) =>
            await eventTopicObserver.SubscribeAsync<string, Person>(
                $"typing_to_{currentUserEmail}", cancellationToken)
                .ConfigureAwait(false);
    }
}