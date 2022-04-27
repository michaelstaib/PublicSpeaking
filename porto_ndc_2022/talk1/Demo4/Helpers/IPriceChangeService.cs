namespace Demo;

public interface IPriceChangeService
{
    IAsyncEnumerable<string> ReadAsync(CancellationToken cancellationToken);
}