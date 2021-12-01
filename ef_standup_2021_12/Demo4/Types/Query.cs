namespace Demo;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks(BookContext bookContext)
        => bookContext.Publications.OfType<Book>();

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors(BookContext bookContext)
        => bookContext.Authors;

    [UsePaging]
    [UseProjection]
    public IQueryable<Publication> GetPublications(BookContext bookContext)
        => bookContext.Publications;

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Reader> GetReaders(BookContext bookContext)
        => bookContext.Publications.OfType<Reader>();

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Author> GetAuthorById(int id, BookContext bookContext)
        => bookContext.Authors.Where(t => t.Id == id);
}
