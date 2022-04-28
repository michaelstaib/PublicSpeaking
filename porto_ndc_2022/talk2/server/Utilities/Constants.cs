using System.Runtime.CompilerServices;

namespace Demo;

public static class Constants
{
    public const string PriceInfoService = nameof(PriceInfoService);
    public const string Watchlists = nameof(Watchlists);
    public const string OnPriceChange = nameof(OnPriceChange);
    public const string OnPriceChangeProcessing = nameof(OnPriceChangeProcessing);
    public static string OnNotification(string username)
        => $"OnNotification({username})";
    public const string Headers = "Authorization=ApiKey dmhkWFVvQUJHVVNZOUs1MVEtM3k6V3dLYnZBeEFTeFNCemhGZmdnSldfUQ==";
}