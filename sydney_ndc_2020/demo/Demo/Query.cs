using System.Linq;
using System.Threading.Tasks;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Query
    {
        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] BookContext dbContext) =>
            dbContext.Books;

        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] BookContext dbContext) =>
            dbContext.Authors;

        [UseDbContext(typeof(BookContext))]
        [UseFiltering]
        [UseSorting]
        public Task<Author> GetAuthorByIdAsync(int id, [ScopedService] BookContext dbContext) =>
            dbContext.Authors.FirstOrDefaultAsync(t => t.Id == id);
    }
}
