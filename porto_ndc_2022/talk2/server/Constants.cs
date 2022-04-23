namespace Demo;

public static class Constants
{
    public const string PriceInfoService = nameof(PriceInfoService);
    public const string Watchlists = nameof(Watchlists);
    public const string OnPriceChange = nameof(OnPriceChange);
    public const string OnPriceChangeProcessing = nameof(OnPriceChangeProcessing);
    public const string AssetPriceHistory = nameof(AssetPriceHistory);
    public static string OnNotification(string username)
        => $"OnNotification({username})";
}