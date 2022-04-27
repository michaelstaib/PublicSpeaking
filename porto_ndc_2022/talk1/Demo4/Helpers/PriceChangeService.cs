using System.Runtime.CompilerServices;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Demo.Helpers;

public class PriceChangeService : IPriceChangeService
{
    private readonly ITopicEventReceiver _receiver;

    public PriceChangeService(ITopicEventReceiver receiver)
    {
        _receiver = receiver;
    }

    public async IAsyncEnumerable<string> ReadAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ISourceStream stream = await _receiver.SubscribeAsync<string, string>(Constants.OnPriceChange, cancellationToken);

        await foreach (string symbol in stream.ReadEventsAsync().WithCancellation(cancellationToken))
        {
            yield return symbol;
        }
    }
}