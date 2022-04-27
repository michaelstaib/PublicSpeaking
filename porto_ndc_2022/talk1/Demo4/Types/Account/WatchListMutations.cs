using Demo.Types.Errors;

namespace Demo.Types.Account;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class WatchlistMutations
{
    [Error<UnknownAssetException>]
    [Error<NotAuthenticatedException>]
    public async Task<AddAssetToWatchlistPayload> AddAssetToWatchlistAsync(
        string symbol,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException(Constants.Watchlists);
        }

        if (!await context.Assets.AnyAsync(t => t.Symbol == symbol, cancellationToken))
        {
            throw new UnknownAssetException(symbol);
        }

        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

        if (watchlist is null)
        {
            watchlist = new Watchlist { User = username };
            context.Watchlists.Add(watchlist);
        }

        watchlist.AddSymbols(symbol);

        await context.SaveChangesAsync(cancellationToken);

        return new AddAssetToWatchlistPayload(symbol, watchlist);
    }

    [Error<UnknownAssetException>]
    [Error<NotAuthenticatedException>]
    public async Task<AddAssetsToWatchlistPayload> AddAssetsToWatchlistAsync(
        string[] symbols,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException(Constants.Watchlists);
        }

        if (!await context.Assets.AnyAsync(t => symbols.Contains(t.Symbol), cancellationToken))
        {
            throw new UnknownAssetException(symbols);
        }

        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

        if (watchlist is null)
        {
            watchlist = new Watchlist { User = username };
            context.Watchlists.Add(watchlist);
        }

        watchlist.AddSymbols(symbols);
        await context.SaveChangesAsync(cancellationToken);

        return new AddAssetsToWatchlistPayload(symbols, watchlist);
    }

    [Error<UnknownAssetException>]
    [Error<NotAuthenticatedException>]
    [UseMutationConvention]
    public async Task<RemoveAssetFromWatchlistPayload> RemoveAssetFromWatchlistAsync(
        string symbol,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException(Constants.Watchlists);
        }

        if (!await context.Assets.AnyAsync(t => t.Symbol == symbol, cancellationToken))
        {
            throw new UnknownAssetException(symbol);
        }

        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

        if (watchlist is null)
        {
            return new RemoveAssetFromWatchlistPayload(null, null);
        }
        else
        {
            watchlist.RemoveSymbols(symbol);
        }

        await context.SaveChangesAsync(cancellationToken);

        return new RemoveAssetFromWatchlistPayload(symbol, watchlist);
    }

    [Error<UnknownAssetException>]
    [Error<NotAuthenticatedException>]
    [UseMutationConvention(PayloadFieldName = "removedAssets")]
    public async Task<RemoveAssetsFromWatchlistPayload> RemoveAssetsFromWatchlistAsync(
        string[] symbols,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException(Constants.Watchlists);
        }

        if (!await context.Assets.AnyAsync(t => symbols.Contains(t.Symbol), cancellationToken))
        {
            throw new UnknownAssetException(symbols);
        }

        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

        if (watchlist is null)
        {
            return new RemoveAssetsFromWatchlistPayload(null, null);
        }
        else
        {
            watchlist.RemoveSymbols(symbols);
        }

        await context.SaveChangesAsync(cancellationToken);

        return new RemoveAssetsFromWatchlistPayload(symbols, watchlist);
    }

    [Error<UnknownAssetException>]
    [Error<NotAuthenticatedException>]
    [Error<UnknownWatchlistException>]
    [Error<IndexOutOfRangeException>]
    public async Task<Watchlist> ChangeAssetPositionInWatchlistAsync(
        string symbol,
        int index,
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException(Constants.Watchlists);
        }

        if (!await context.Assets.AnyAsync(t => t.Symbol == symbol, cancellationToken))
        {
            throw new UnknownAssetException(symbol);
        }

        Watchlist? watchlist = await context.Watchlists.FirstOrDefaultAsync(t => t.User == username, cancellationToken);

        if (watchlist is null)
        {
            throw new UnknownWatchlistException(username);
        }

        var symbols = watchlist.GetSymbols();

        if (symbols.Count <= index)
        {
            throw new IndexOutOfRangeException("The specified index is outside of the list.");
        }

        symbols.Remove(symbol);
        symbols.Insert(index, symbol);
        watchlist.SetSymbols(symbols);

        await context.SaveChangesAsync(cancellationToken);

        return watchlist;
    }
}
