using System.Threading;
using System.Threading.Tasks;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace Demo
{
    public class Mutation
    {
        [UseDbContext(typeof(BookContext))]
        public async Task<AddAuthorPayload> AddAuthorAsync(
            AddAuthorInput input,
            [ScopedService] BookContext dbContext)
        {
            var author = new Author 
            {
                Name = input.Name
            };

            dbContext.Authors.Add(author);
            await dbContext.SaveChangesAsync();

            return new AddAuthorPayload(author);
        }

        [UseDbContext(typeof(BookContext))]
        public async Task<AddBookPayload> AddBookAsync(
            AddBookInput input,
            [ScopedService] BookContext dbContext,
            CancellationToken cancellationToken)
        {
            var book = new Book 
            {
                Title = input.Title,
                AuthorId = input.AuthorId
            };

            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddBookPayload(book);
        }
    }
}
