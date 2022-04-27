using Demo.Transport;
using HotChocolate.Subscriptions;

namespace Microsoft.Extensions.DependencyInjection;

public static class HelersServiceCollectionExtensions
{
    public static IServiceCollection AddHelperServices(this IServiceCollection services)
        => services
            .AddSingleton<IFileStorage>(_ => new FileSystemStorage("./wwwroot/images"))
            .AddHostedService<AssetPriceChangeProcessor>()
            .AddSingleton<IPriceChangeService, PriceChangeService>()
            .AddGraphQLServer()
            .AddQueryType()
            .AddMutationType()
            .AddSubscriptionType()
            .AddType<UploadType>()
            .AddGlobalObjectIdentification()
            .AddMutationConventions()
            .AddFiltering()
            .AddSorting()
            .RegisterService<IFileStorage>()
            .RegisterService<ITopicEventSender>()
            .RegisterService<ITopicEventReceiver>()
            .AddHttpRequestInterceptor<CustomHttpRequestInterceptor>()
            .AddSocketSessionInterceptor<CustomSocketSessionInterceptor>()
            .RegisterDbContext<AssetContext>(DbContextKind.Pooled)
            .Services;
}