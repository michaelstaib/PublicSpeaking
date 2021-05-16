using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Types.DataLoader;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Query
    {
        [UseDbContext(typeof(BookContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks(
            [ScopedService] BookContext dbContext) =>
            dbContext.Books;

        [UseDbContext(typeof(BookContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors(
            [ScopedService] BookContext dbContext) =>
            dbContext.Authors;

        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public Task<Author> GetAuthorByIdAsync(
            int id, 
            AuthorDataLoader authorDataLoader, 
            CancellationToken cancellationToken) =>
            authorDataLoader.LoadAsync(id, cancellationToken);
    }
}
