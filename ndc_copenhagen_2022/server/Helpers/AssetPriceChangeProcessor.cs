using System.Security.Claims;
using System.Text.Json;
using HotChocolate.Subscriptions;

namespace Demo.Helpers;

public sealed partial class AssetPriceChangeProcessor : IHostedService, IDisposable
{
    private readonly CancellationTokenSource _cts = new();
    private readonly IDbContextFactory<AssetContext> _contextFactory;
    private readonly IFileStorage _fileStorage;
    private readonly ITopicEventSender _sender;
    private bool _disposed;

    private readonly string[] _symbols = new[]
    {
        "BTC",
        "BCH",
        "ALGO",
        "XLM",
        "CRV",
        "WLUNA",
        "ETH2",
        "ETH",
        "USDT",
        "USDC",
        "SOL",
        "ADA",
        "AVAX",
        "DOT",
        "DOGE",
        "UST",
        "SHIB",
        "MATIC",
        "WBTC",
        "CRO",
        "DAI",
        "ATOM",
        "LTC",
        "LINK",
        "UNI",
        "MANA",
        "ETC",
        "ICP",
        "FIL",
        "AXS",
        "XTZ",
        "APE",
        "AAVE",
        "ZEC",
        "EOS",
        "MKR",
        "GRT",
        "STX",
        "GALA",
        "QNT",
        "BAT",
        "CHZ",
        "CGLD",
        "ENJ",
        "AMP",
        "DASH",
        "PAX",
        "LRC",
        "IOTX",
        "COMP",
        "YFI",
        "1INCH",
        "BNT",
        "ANKR",
        "OMG",
        "RNDR",
        "LPT",
        "UMA",
        "SNX",
        "RLY",
        "ZEN",
        "VGX",
        "GLM",
        "GNT",
        "ZRX",
        "STORJ",
        "KEEP",
        "SUSHI",
        "SKL",
        "IMX",
        "POLY",
        "REN",
        "SPELL",
        "BTRST",
        "ENS",
        "NU",
        "PLA",
        "PERP",
        "DESO",
        "FET",
        "SUPER",
        "POWR",
        "TRIBE",
        "XYO",
        "REQ",
        "COTI",
        "FX",
        "SNT",
        "CVC",
        "ALICE",
        "RGT",
        "API3",
        "OXT",
        "CTSI",
        "NMR",
        "ACH",
        "OGN",
        "TRAC",
        "REP",
        "BICO",
        "RLC",
        "NKN",
        "MIR",
        "POLS",
        "RAD",
        "ORN",
        "BAND",
        "MASK",
        "MPL",
        "TRU",
        "ALCX",
        "MLN",
        "JASMY",
        "PRO",
        "AIOZ",
        "IDEX",
        "BADGER",
        "ARPA",
        "CLV",
        "LOOM",
        "GTC",
        "BAL",
        "AERGO",
        "AGLD",
        "YFII",
        "RAI",
        "FIDA",
        "FOX",
        "FORTH",
        "COVAL",
        "LCX",
        "DIA",
        "FARM",
        "ERN",
        "QUICK",
        "DDX",
        "ASM",
        "NCT",
        "RBN",
        "HIGH",
        "BLZ",
        "RARI",
        "TRB",
        "BOND",
        "LQTY",
        "DNT",
        "MUSD",
        "QSP",
        "MDT",
        "INV",
        "SHPING",
        "AUCTION",
        "UNFI",
        "GODS",
        "SUKU",
        "KRL",
        "GYEN",
        "CTX",
        "UPI",
        "GFI",
        "PLU",
        "AVT",
        "KNC",
        "MCO2",
        "WCFG",
        "ORCA",
        "SYN"
    };

    public AssetPriceChangeProcessor(
        IDbContextFactory<AssetContext> contextFactory,
        IFileStorage fileStorage,
        ITopicEventSender sender)
    {
        _contextFactory = contextFactory;
        _fileStorage = fileStorage;
        _sender = sender;
    }

    public async Task StartAsync(CancellationToken stoppingToken)
    {
        using AssetContext context = await _contextFactory.CreateDbContextAsync(stoppingToken);
        await context.Database.EnsureCreatedAsync(stoppingToken);

        await SeedAssetsAsync(stoppingToken);
        BeginUpdatePrices();
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _cts.Cancel();
        return Task.CompletedTask;
    }

    private void BeginUpdatePrices()
        => Task.Factory.StartNew(
            async () =>
            {
                await UpdateImagesAsync(_cts.Token);
                await UpdatePricesAsync(_cts.Token);
            },
            _cts.Token,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);

    private async Task SeedAssetsAsync(CancellationToken cancellationToken)
    {
        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

        var storedSymbols = _symbols.Except(await context.Assets.Select(t => t.Symbol!).ToListAsync(cancellationToken)).ToArray();
        if (storedSymbols.Length == 0)
        {
            return;
        }

        var map = await LoadAssetsAsync(storedSymbols, cancellationToken);

        foreach (Asset asset in map.Values)
        {
            context.Assets.Add(asset);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    private static async Task<IReadOnlyDictionary<string, Asset>> LoadAssetsAsync(
        IReadOnlyList<string> symbols,
        CancellationToken cancellationToken)
    {
        var map = new Dictionary<string, Asset>();

        try
        {
            using var client = CreateClient();
            client.BaseAddress = new("https://ccc-workshop-eu-functions.azurewebsites.net");

            using var assetRequest = new HttpRequestMessage(HttpMethod.Get, $"api/asset?symbols={string.Join(",", symbols)}");
            using var assetResponse = await client.SendAsync(assetRequest, cancellationToken);
            assetResponse.EnsureSuccessStatusCode();

            var content = await assetResponse.Content.ReadAsByteArrayAsync(cancellationToken);
            var assets = JsonDocument.Parse(content).RootElement;

            foreach (JsonElement assetInfo in assets.EnumerateArray())
            {
                string symbol = assetInfo.GetProperty("symbol").GetString()!;

                var asset = new Asset
                {
                    Symbol = symbol,
                    Name = assetInfo.GetProperty("name").GetString(),
                    Slug = assetInfo.GetProperty("slug").GetString(),
                    Description = assetInfo.GetProperty("description").GetString(),
                    Color = assetInfo.GetProperty("color").GetString(),
                    ImageKey = assetInfo.GetProperty("imageUrl").GetString(),
                    Website = assetInfo.GetProperty("website").GetString(),
                    WhitePaper = assetInfo.GetProperty("whitePaper").GetString(),
                };

                map.Add(symbol, asset);
            }
        }
        catch
        {
            // ignore any errors.
        }

        return map;
    }

    private async Task UpdateImagesAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
            var assets = await context.Assets.ToListAsync(cancellationToken);

            foreach (var asset in assets)
            {
                if (asset.ImageKey?.StartsWith("https://") == true)
                {
                    asset.ImageKey = await TryStoreImage(asset.ImageKey, _fileStorage, cancellationToken);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            // ignore any errors.
        }
    }

    private async Task UpdatePricesAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                using var client = CreateClient();
                using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

                client.BaseAddress = new("https://ccc-workshop-eu-functions.azurewebsites.net");

                var assets = await context.Assets.Select(t => new { t.Id, t.Symbol }).ToDictionaryAsync(t => t.Symbol!, t => t.Id, cancellationToken);
                if (assets.Count > 0)
                {
                    var prices = await context.AssetPrices.Where(t => assets.Keys.Contains(t.Symbol!)).ToDictionaryAsync(t => t.Symbol!, cancellationToken);
                    var updates = await LoadCurrentAssetPricesAsync(assets.Keys, client, cancellationToken);

                    foreach (var update in updates)
                    {
                        prices.TryGetValue(update.Symbol, out var price);
                        await UpdateAssetPriceAsync(price, update, assets[update.Symbol], context, cancellationToken);
                    }
                }
            }
            catch
            {
                // if there is an error we will retry
            }

            await Task.Delay(Random.Shared.Next(10_000, 20_000), cancellationToken);
        }
    }

    private static async Task<IReadOnlyList<UpdateAssetPriceDto>> LoadCurrentAssetPricesAsync(
        IReadOnlyCollection<string> keys,
        HttpClient client,
        CancellationToken cancellationToken)
    {
        using var priceRequest = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/asset/price?symbols={string.Join(",", keys)}");

        using var changeRequest = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/asset/price/change?symbols={string.Join(",", keys)}&span=Day");

        using var priceResponse = await client.SendAsync(priceRequest, cancellationToken);
        priceResponse.EnsureSuccessStatusCode();

        using var changeResponse = await client.SendAsync(changeRequest, cancellationToken);
        changeResponse.EnsureSuccessStatusCode();

        var priceContent = await priceResponse.Content.ReadAsByteArrayAsync(cancellationToken);
        var changeContent = await changeResponse.Content.ReadAsByteArrayAsync(cancellationToken);

        var priceDoc = JsonDocument.Parse(priceContent);
        var changeDoc = JsonDocument.Parse(changeContent);

        var changeLookup = changeDoc.RootElement.EnumerateArray().ToDictionary(t => t.GetProperty("symbol").GetString()!);
        var list = new List<UpdateAssetPriceDto>();

        foreach (JsonElement priceInfo in priceDoc.RootElement.EnumerateArray())
        {
            if (changeLookup.TryGetValue(priceInfo.GetProperty("symbol").GetString()!, out var change))
            {
                list.Add(ToUpdateAssetPriceInput(priceInfo, change));
            }
        }

        return list;
    }

    private async Task UpdateAssetPriceAsync(
        AssetPrice? price,
        UpdateAssetPriceDto input,
        int assetId,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        UpdateAssetPriceDto? original = ToUpdateAssetPriceInput(price);

        if (price is null)
        {
            price = new AssetPrice { AssetId = assetId };
            context.AssetPrices.Add(price);
        }

        price.Change24Hour = input.Change24Hour;
        price.CirculatingSupply = input.CirculatingSupply;
        price.Currency = input.Currency;
        price.High24Hour = input.High24Hour;
        price.LastPrice = Math.Round(input.LastPrice, 2);
        price.Low24Hour = input.Low24Hour;
        price.MarketCap = input.MarketCap;
        price.MaxSupply = input.MaxSupply;
        price.Open24Hour = input.Open24Hour;
        price.TradableMarketCapRank = input.TradableMarketCapRank;
        price.Symbol = input.Symbol;
        price.TradingActivity = input.TradingActivity;
        price.Volume24Hour = input.Volume24Hour;
        price.VolumePercentChange24Hour = input.VolumePercentChange24Hour;
        price.ModifiedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        if (original is null || !input.Equals(original))
        {
            await Task.Delay(Random.Shared.Next(200, 600), cancellationToken);
            await _sender.SendAsync(Constants.OnPriceChangeProcessing, input, cancellationToken);
            await _sender.SendAsync(Constants.OnPriceChange, input.Symbol, cancellationToken);
        }
    }

    private static UpdateAssetPriceDto ToUpdateAssetPriceInput(JsonElement price, JsonElement priceChange)
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

    private static async Task<string?> TryStoreImage(
        string imageUrl,
        IFileStorage storage,
        CancellationToken cancellationToken)
    {
        using var client = CreateClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, imageUrl);
        using var response = await client.SendAsync(request, cancellationToken);
        await using var stream = response.Content.ReadAsStream(cancellationToken);
        return await storage.UploadAsync(stream, cancellationToken);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
            _cts.Dispose();
            _disposed = true;
        }
    }

    private static UpdateAssetPriceDto? ToUpdateAssetPriceInput(AssetPrice? price)
        => price is null
            ? null
            : new(price.Symbol!,
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

    private sealed record UpdateAssetPriceDto(
        string Symbol,
        string Currency,
        double LastPrice,
        Optional<double> MarketCap,
        Optional<double> TradableMarketCapRank,
        Optional<double> Volume24Hour,
        Optional<double> VolumePercentChange24Hour,
        Optional<double> CirculatingSupply,
        Optional<double> MaxSupply,
        Optional<double> High24Hour,
        Optional<double> Low24Hour,
        Optional<double> Open24Hour,
        Optional<double> TradingActivity,
        Optional<double> Change24Hour);
}
