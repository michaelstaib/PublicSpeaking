using System.Text.Json;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using HotChocolate.Types.Pagination.Extensions;

namespace Demo.Types.Assets;

public sealed class AssetPriceChangeType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor
            .Name("AssetPriceChange")
            .IsOfType(IsAssetPriceChangeType);

        descriptor
            .Field("id")
            .Type<NonNullType<IdType>>()
            .FromJson(obj =>
            {
                if (obj.TryGetProperty("symbol", out var symbol) &&
                    obj.TryGetProperty("span", out var span))
                {
                    return $"{symbol.GetString()}:{span.GetString()}";
                }

                return null;
            });

        descriptor
            .Field("percentageChange")
            .Type<NonNullType<FloatType>>()
            .FromJson();

        descriptor
            .Field<Resolvers>(t => t.GetHistoryAsync(default, default, default!, default!, default))
            .UsePaging<AssetPriceHistoryType>();
    }

    private static bool IsAssetPriceChangeType(IResolverContext context, object resolverResult)
        => resolverResult is JsonElement element &&
            element.TryGetProperty("percentageChange", out _);

    private class Resolvers
    {
        public async Task<Connection<JsonElement>> GetHistoryAsync(
            [ScopedState] ChangeSpan span,
            [Parent] JsonElement parent,
            AssetPriceHistoryDataLoader dataLoader,
            IResolverContext context,
            CancellationToken cancellationToken)
        {
            string symbol = parent.GetProperty("symbol").GetString()!;
            JsonElement history = await dataLoader.LoadAsync(new KeyAndSpan(symbol, span), cancellationToken);
            return await history.GetProperty("entries").EnumerateArray().ToArray().ApplyCursorPaginationAsync(context, cancellationToken: cancellationToken);
        }
    }
}