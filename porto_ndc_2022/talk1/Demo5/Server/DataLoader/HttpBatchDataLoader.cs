using System.Text.Json;

namespace Demo.DataLoader;

public abstract class HttpBatchDataLoader<TKey>
    : BatchDataLoader<TKey, JsonElement>
    where TKey : notnull
{
    protected HttpBatchDataLoader(
        IHttpClientFactory clientFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        ClientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
    }

    public IHttpClientFactory ClientFactory { get; }

    protected sealed override async Task<IReadOnlyDictionary<TKey, JsonElement>> LoadBatchAsync(
        IReadOnlyList<TKey> keys,
        CancellationToken cancellationToken)
    {
        using var client = ClientFactory.CreateClient(Constants.PriceInfoService);
        return await LoadBatchAsync(keys, client, cancellationToken);
    }

    protected abstract Task<IReadOnlyDictionary<TKey, JsonElement>> LoadBatchAsync(
        IReadOnlyList<TKey> keys,
        HttpClient client,
        CancellationToken cancellationToken);
}