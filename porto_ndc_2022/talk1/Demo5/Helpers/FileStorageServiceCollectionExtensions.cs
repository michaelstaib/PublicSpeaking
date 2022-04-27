using Demo.Transport;
using HotChocolate.Subscriptions;

namespace Microsoft.Extensions.DependencyInjection;

public static class HelersServiceCollectionExtensions
{
    public static IServiceCollection AddHelperServices(this IServiceCollection services)
        => services
            .AddSingleton<IFileStorage>(_ => new FileSystemStorage("./wwwroot/images"))
            .AddHostedService<AssetPriceChangeProcessor>()
            .AddGraphQLServer()
            .RegisterService<IFileStorage>()
            .RegisterService<ITopicEventSender>()
            .RegisterService<ITopicEventReceiver>()
            .AddHttpRequestInterceptor<CustomHttpRequestInterceptor>()
            .AddSocketSessionInterceptor<CustomSocketSessionInterceptor>()
            .Services;
}