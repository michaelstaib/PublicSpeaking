using System;
using System.Linq;
using System.Threading;
using Demo.Data;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Demo
{
    public class Query
    {
        private readonly BookContext _bookContext;

        public Query(BookContext bookContext)
        {
            if (bookContext is null)
            {
                throw new ArgumentNullException(nameof(bookContext));
            }

            _bookContext = bookContext;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks() => 
            _bookContext.Books;

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors() => 
            _bookContext.Authors;

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Author> GetAuthorByIdAsync(int id) => 
            _bookContext.Authors.Where(t => t.Id == id);
    }
}
