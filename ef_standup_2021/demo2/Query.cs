using System.Linq;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Types;

namespace Demo
{
    public class Query
    {
        [Serial]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] BookContext context) =>
            context.Books;
    }
}
