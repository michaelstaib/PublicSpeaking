namespace Demo;

public class Query
{
    public async IAsyncEnumerable<Book> GetBooksAsync(
        BookContext bookContext,
        CancellationToken cancellationToken)
    {
        await foreach (Book book in bookContext.Books.AsAsyncEnumerable().WithCancellation(cancellationToken))
        {
            await Task.Delay(500);
            yield return book;
        }
    }   
}
