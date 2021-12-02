namespace Demo;

public class Mutation
{
    [Payload, Input, Error(typeof(InvalidOperationException))]
    public async Task<Author> AddAuthorAsync(
        string name,
        BookContext bookContext,
        CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Name = name
        };

        throw new InvalidOperationException("Foo");

        bookContext.Authors.Add(author);
        await bookContext.SaveChangesAsync(cancellationToken);

        return author;
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
