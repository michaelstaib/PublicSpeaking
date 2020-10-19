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
    }
}
