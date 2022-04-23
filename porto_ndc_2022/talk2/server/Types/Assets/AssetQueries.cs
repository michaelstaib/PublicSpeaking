using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace Demo.Types.Assets;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class AssetQueries
{
    [UsePaging]
    [UseFiltering(typeof(AssetFilterInputType))]
    [UseSorting(typeof(AssetSortInputType))]
    public IQueryable<Asset> GetAssets(AssetContext context, IResolverContext resolverContext)
        => resolverContext.ArgumentLiteral<IValueNode>("order").Kind is SyntaxKind.NullValue
            ? context.Assets.OrderBy(t => t.Symbol)
            : context.Assets;

    public async Task<Asset?> GetAssetBySlug(
        string slug,
        AssetBySlugDataLoader assetBySlug,
        CancellationToken cancellationToken)
        => await assetBySlug.LoadAsync(slug, cancellationToken);

    public async Task<IEnumerable<Asset?>> GetAssetsBySlug(
        string[] slugs,
        AssetBySlugDataLoader assetBySlug,
        CancellationToken cancellationToken)
        => await assetBySlug.LoadAsync(slugs, cancellationToken);

    public async Task<Asset?> GetAssetBySymbol(
        string symbol,
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => await assetBySymbol.LoadAsync(symbol, cancellationToken);

    public async Task<IEnumerable<Asset?>> GetAssetsBySymbol(
        string[] symbols,
        AssetBySymbolDataLoader assetBySymbol,
        CancellationToken cancellationToken)
        => await assetBySymbol.LoadAsync(symbols, cancellationToken);

    public async Task<Asset?> GetAssetById(
        [ID(nameof(Asset))] int id,
        AssetByIdDataLoader assetById,
        CancellationToken cancellationToken)
        => await assetById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Asset?>> GetAssetsById(
        [ID(nameof(Asset))] int[] ids,
        AssetByIdDataLoader assetById,
        CancellationToken cancellationToken)
        => await assetById.LoadAsync(ids, cancellationToken);
}