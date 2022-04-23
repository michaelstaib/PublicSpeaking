#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class UnknownWatchlistException : Exception
{
    public UnknownWatchlistException(string username)
        : base($"The user `{username}` has no watchlist.")
    {
        Username = username;
    }

    public string Username { get; }
}
