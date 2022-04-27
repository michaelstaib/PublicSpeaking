using System.Text.Json;
using Demo.Data;

namespace Demo.Types.Assets;

public static class AssetPriceExtensions
{
    public static UpdateAssetPriceInput ToUpdateAssetPriceInput(this AssetPrice price)
        => new(price.Symbol!,
            price.Currency!,
            price.LastPrice,
            price.MarketCap,
            price.TradableMarketCapRank,
            price.Volume24Hour,
            price.VolumePercentChange24Hour,
            price.CirculatingSupply,
            price.MaxSupply,
            price.High24Hour,
            price.Low24Hour,
            price.Open24Hour,
            price.TradingActivity,
            price.Change24Hour);

    public static UpdateAssetPriceInput Normalize(this UpdateAssetPriceInput update, UpdateAssetPriceInput original)
        => new(update.Symbol,
            update.Currency,
            update.LastPrice,
            update.MarketCap.HasValue ? update.MarketCap : original.MarketCap,
            update.TradableMarketCapRank.HasValue ? update.TradableMarketCapRank : original.TradableMarketCapRank,
            update.Volume24Hour.HasValue ? update.Volume24Hour : original.Volume24Hour,
            update.VolumePercentChange24Hour.HasValue ? update.VolumePercentChange24Hour : original.VolumePercentChange24Hour,
            update.CirculatingSupply.HasValue ? update.CirculatingSupply : original.CirculatingSupply,
            update.MaxSupply.HasValue ? update.MaxSupply : original.MaxSupply,
            update.High24Hour.HasValue ? update.High24Hour : original.High24Hour,
            update.Low24Hour.HasValue ? update.Low24Hour : original.Low24Hour,
            update.Open24Hour.HasValue ? update.Open24Hour : original.Open24Hour,
            update.TradingActivity.HasValue ? update.TradingActivity : original.TradingActivity,
            update.Change24Hour.HasValue ? update.Change24Hour : original.Change24Hour);

    public static UpdateAssetPriceInput ToUpdateAssetPriceInput(this JsonElement price, JsonElement priceChange)
        => new(price.GetProperty("symbol").GetString()!,
            price.GetProperty("currency").GetString()!,
            price.GetProperty("lastPrice").GetDouble(),
            price.GetProperty("marketCap").GetDouble(),
            price.GetProperty("tradableMarketCapRank").GetDouble(),
            price.GetProperty("volume24Hour").GetDouble(),
            price.GetProperty("volumePercentChange24Hour").GetDouble(),
            price.GetProperty("circulatingSupply").GetDouble(),
            price.GetProperty("maxSupply").GetDouble(),
            price.GetProperty("high24Hour").GetDouble(),
            price.GetProperty("low24Hour").GetDouble(),
            price.GetProperty("open24Hour").GetDouble(),
            price.GetProperty("tradingActivity").GetDouble(),
            priceChange.GetProperty("percentageChange").GetDouble());
}