namespace Demo;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks(BookContext bookContext)
        => bookContext.Books;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors(BookContext bookContext)
        => bookContext.Authors;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Author> GetAuthorById(int id, BookContext bookContext)
        => bookContext.Authors.Where(t => t.Id == id);
}
