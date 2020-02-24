using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace Demo
{
    public class Subscription
    {
        public async ValueTask<IAsyncEnumerable<Person>> OnPerson(
            [Service]IEventTopicObserver eventTopicObserver,
            CancellationToken cancellationToken) =>
            await eventTopicObserver.SubscribeAsync<string, Person>(
                "new", cancellationToken);
    }
}
