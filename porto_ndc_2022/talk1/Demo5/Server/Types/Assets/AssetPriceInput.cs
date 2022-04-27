namespace Demo.Types.Assets;

public record UpdateAssetPriceInput(
    string Symbol,
    string Currency,
    double LastPrice,
    [property: DefaultValue(0)] Optional<double> MarketCap,
    [property: DefaultValue(0)] Optional<double> TradableMarketCapRank,
    [property: DefaultValue(0)] Optional<double> Volume24Hour,
    [property: DefaultValue(0)] Optional<double> VolumePercentChange24Hour,
    [property: DefaultValue(0)] Optional<double> CirculatingSupply,
    [property: DefaultValue(0)] Optional<double> MaxSupply,
    [property: DefaultValue(0)] Optional<double> High24Hour,
    [property: DefaultValue(0)] Optional<double> Low24Hour,
    [property: DefaultValue(0)] Optional<double> Open24Hour,
    [property: DefaultValue(0)] Optional<double> TradingActivity,
    [property: DefaultValue(0)] Optional<double> Change24Hour);
