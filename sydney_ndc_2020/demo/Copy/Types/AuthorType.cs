using System.Linq;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Demo.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor
                .Field(t => t.Books)
                .ResolveWith<Resolvers>(t => t.GetBooks(default!, default!))
                .UseDbContext<BookContext>()
                .UseFiltering()
                .UseSorting();
        }

        private class Resolvers
        {
            public IQueryable<Book> GetBooks(
                Author author,
                [ScopedService] BookContext dbContext) =>
                dbContext.Books.Where(t => t.AuthorId == author.Id);
        }
    }
}