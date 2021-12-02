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


[ExtendObjectType(typeof(Book))]
public class BookDetails
{
    public async Task<string> GetDetails()
    {
        await Task.Delay(500);
        return "hello";
    }
}