using System.Threading;
using System.Threading.Tasks;
using Demo.Data;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace Demo
{
    public class Mutation
    {
        private readonly BookContext _bookContext;

        public Mutation(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<AddAuthorPayload> AddAuthorAsync(
            AddAuthorInput input,
            CancellationToken cancellationToken)
        {
            var author = new Author 
            {
                Name = input.Name
            };

            _bookContext.Authors.Add(author);
            await _bookContext.SaveChangesAsync(cancellationToken);

            return new AddAuthorPayload(author);
        }

        public async Task<AddBookPayload> AddBookAsync(
            AddBookInput input,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var book = new Book 
            {
                Title = input.Title,
                AuthorId = input.AuthorId
            };

            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnBookReleased), book, cancellationToken);

            return new AddBookPayload(book);
        }
    }
}
