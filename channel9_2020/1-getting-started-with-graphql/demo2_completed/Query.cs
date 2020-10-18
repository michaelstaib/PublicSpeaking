using System.Linq;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Demo
{
    public class Query 
    {
        [UseDbContext(typeof(BookContext))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] BookContext context) =>
            context.Books;
    }
}
