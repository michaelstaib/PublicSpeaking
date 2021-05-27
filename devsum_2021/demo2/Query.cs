using System.Linq;
using Demo.Data;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Demo
{
    public class Query
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] BookContext context) =>
            context.Books;
    }

    [ExtendObjectType(typeof(Book))]
    public class BookDetails
    {
        public string GetSummary() => "Something bla bla";
    }
}
