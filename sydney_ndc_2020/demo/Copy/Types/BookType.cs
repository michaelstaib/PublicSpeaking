using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using HotChocolate;
using HotChocolate.Types;

namespace Demo.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor
                .Field(t => t.Author)
                .ResolveWith<Resolvers>(t => t.GetAuthorAsync(default!, default!))
                .UseDbContext<BookContext>();
        }

        private class Resolvers
        {
            public Task<Author> GetAuthorAsync(
                Book book,
                [ScopedService] BookContext dbContext) =>
                dbContext.Authors.FirstOrDefaultAsync(t => t.Id == book.AuthorId);
        }
    }
}