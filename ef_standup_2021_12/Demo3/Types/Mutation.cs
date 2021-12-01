namespace Demo;

public class Mutation
{
    public async Task<AddAuthorPayload> AddAuthorAsync(
        AddAuthorInput input,
        BookContext bookContext,
        CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Name = input.Name
        };

        bookContext.Authors.Add(author);
        await bookContext.SaveChangesAsync(cancellationToken);

        return new AddAuthorPayload(author);
    }

    public async Task<AddBookPayload> AddBookAsync(
        AddBookInput input,
        BookContext bookContext,
        ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = input.Title,
            AuthorId = input.AuthorId
        };

        bookContext.Books.Add(book);
        await bookContext.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(nameof(Subscription.OnBookReleased), book, cancellationToken);

        return new AddBookPayload(book);
    }
}
