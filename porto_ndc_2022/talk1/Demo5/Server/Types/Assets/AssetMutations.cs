using Demo.Types.Errors;
using HotChocolate.Subscriptions;

namespace Demo.Types.Assets;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class AssetMutations
{
    [UseMutationConvention(PayloadFieldName = "importedAsset")]
    public async Task<Asset> ImportAssetAsync(
        string symbol,
        IFileStorage storage,
        AssetContext context,
        AssetImportDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        Asset asset = await dataLoader.LoadAsync(symbol, cancellationToken);

        if (asset.ImageKey is not null)
        {
            asset.ImageKey = await TryStoreImage(asset.ImageKey, storage, cancellationToken);
        }

        Asset? fromDb = await context.Assets.FirstOrDefaultAsync(t => t.Symbol == symbol, cancellationToken);

        if (fromDb is null)
        {
            context.Assets.Add(asset);
        }
        else
        {
            fromDb.Symbol = asset.Symbol;
            fromDb.Name = asset.Name;
            fromDb.Slug = asset.Slug;
            fromDb.Description = asset.Description;
            fromDb.Color = asset.Color;
            fromDb.ImageKey = asset.ImageKey;
            fromDb.Website = asset.Website;
            fromDb.WhitePaper = asset.WhitePaper;
        }

        await context.SaveChangesAsync(cancellationToken);

        return asset;
    }

    [UseMutationConvention(PayloadFieldName = "importedAssets")]
    public async Task<IReadOnlyList<Asset>> ImportAssetsAsync(
        string[] symbols,
        IFileStorage storage,
        AssetContext context,
        AssetImportDataLoader dataLoader,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<Asset> assets = await dataLoader.LoadAsync(symbols, cancellationToken);

        foreach (Asset asset in assets)
        {
            if (asset.ImageKey is not null)
            {
                asset.ImageKey = await TryStoreImage(asset.ImageKey, storage, cancellationToken);
            }

            Asset? fromDb = await context.Assets.FirstOrDefaultAsync(t => t.Symbol == asset.Symbol, cancellationToken);

            if (fromDb is null)
            {
                context.Assets.Add(asset);
            }
            else
            {
                fromDb.Symbol = asset.Symbol;
                fromDb.Name = asset.Name;
                fromDb.Slug = asset.Slug;
                fromDb.Description = asset.Description;
                fromDb.Color = asset.Color;
                fromDb.ImageKey = asset.ImageKey;
                fromDb.Website = asset.Website;
                fromDb.WhitePaper = asset.WhitePaper;
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        return assets;
    }

    [Error<UnknownAssetException>]
    [UseMutationConvention(PayloadFieldName = "updatedPrice")]
    public async Task<AssetPrice?> UpdateAssetPriceAsync(
        UpdateAssetPriceInput input,
        AssetContext context,
        ITopicEventSender sender,
        CancellationToken cancellationToken)
    {
        AssetPrice? price = await context.AssetPrices.FirstOrDefaultAsync(t => t.Symbol == input.Symbol, cancellationToken);
        UpdateAssetPriceInput? original = price?.ToUpdateAssetPriceInput();

        if (price is null)
        {
            Asset? asset = await context.Assets.FirstOrDefaultAsync(t => t.Symbol == input.Symbol, cancellationToken);
            if (asset is null)
            {
                throw new UnknownAssetException(input.Symbol);
            }

            price = new AssetPrice { Asset = asset };
            context.AssetPrices.Add(price);
        }

        if (original is not null)
        {
            input = input.Normalize(original);
        }

        price.Symbol = input.Symbol;
        price.Currency = input.Currency;
        price.LastPrice = input.LastPrice;

        price.CirculatingSupply =
            input.CirculatingSupply.HasValue
                ? input.CirculatingSupply.Value
                : price.CirculatingSupply;

        price.High24Hour =
            input.High24Hour.HasValue
                ? input.High24Hour.Value
                : price.High24Hour;

        price.Low24Hour =
            input.Low24Hour.HasValue
                ? input.Low24Hour.Value
                : price.Low24Hour;

        price.MarketCap =
            input.MarketCap.HasValue
                ? input.MarketCap.Value
                : price.MarketCap;

        price.MaxSupply =
            input.MaxSupply.HasValue
                ? input.MaxSupply.Value
                : price.MaxSupply;

        price.Open24Hour =
            input.Open24Hour.HasValue
                ? input.Open24Hour.Value
                : price.Open24Hour;

        price.TradableMarketCapRank =
            input.TradableMarketCapRank.HasValue
                ? input.TradableMarketCapRank.Value
                : price.TradableMarketCapRank;

        price.TradingActivity =
            input.TradingActivity.HasValue
                ? input.TradingActivity.Value
                : price.TradingActivity;

        price.Volume24Hour =
            input.Volume24Hour.HasValue
                ? input.Volume24Hour.Value
                : price.Volume24Hour;

        price.VolumePercentChange24Hour =
            input.VolumePercentChange24Hour.HasValue
                ? input.VolumePercentChange24Hour.Value
                : price.VolumePercentChange24Hour;

        context.SaveChanges();

        if (original is null || !input.Equals(original))
        {
            await sender.SendAsync(Constants.OnPriceChangeProcessing, input, cancellationToken);
            await sender.SendAsync(Constants.OnPriceChange, input.Symbol, cancellationToken);
        }

        return price;
    }

    private static async Task<string?> TryStoreImage(
        string imageUrl,
        IFileStorage storage,
        CancellationToken cancellationToken)
    {
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, imageUrl);
        using var response = await client.SendAsync(request, cancellationToken);
        await using var stream = response.Content.ReadAsStream(cancellationToken);
        return await storage.UploadAsync(stream, cancellationToken);
    }
}
