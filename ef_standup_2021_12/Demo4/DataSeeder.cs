public static class DataSeeder
{
    public static void SeedData(this IServiceProvider sp)
    {
        var factory = sp.GetRequiredService<IDbContextFactory<BookContext>>();
        var context = factory.CreateDbContext();
        if (!context.Database.EnsureCreated())
        {
            return;
        }

        var author = new Author()
        {
            Name = "Marcel Proust"
        };
        var author1 = new Author()
        {
            Name = "James Joyce"
        };
        var author2 = new Author()
        {
            Name = "Miguel de Cervantes"
        };
        var author3 = new Author()
        {
            Name = "William C. Ratcliff"
        };
        var author4 = new Author()
        {
            Name = "Peter Sampleman"
        };
        var reader = new Reader()
        {
            Name = "Max Ratcliff"
        };
        var ebook = new Ebook()
        {
            Author = author,
            Title = "In Search of Lost Time",
            Reader = reader
        };
        var ebook2 = new Ebook()
        {
            Author = author1,
            Title = "Ulysses",
            Reader = reader
        };
        var book = new Book()
        {
            Author = author,
            Title = "In Search of Lost Time"
        };
        var book1 = new Book()
        {
            Author = author1,
            Title = "Ulysses"
        };
        var book2 = new Book()
        {
            Author = author2,
            Title = "Don Quixote"
        };
        var paper = new Paper()
        {
            Author = author3,
            Title =
                "Transdermal analgesic activity using hot plate test in rats’ assay",
            FieldOfResearch = "Nanoemulision"
        };
        var paper2 = new Paper()
        {
            Author = author3,
            Title =
                "Enrichment of Eucalyptus oil nanoemulsion by micellar nanotechnology",
            FieldOfResearch = "Nanoemulision"
        };
        var magazine = new Magazine()
        {
            Author = author4,
            Title = "Fast Company",
            Schedule = "By Weekly"
        };
        var vogue = new Magazine()
        {
            Author = author4,
            Title = "Vogue",
            Schedule = "By Weekly"
        };
        context.Authors.Add(author);
        context.Authors.Add(author1);
        context.Authors.Add(author2);
        context.Readers.Add(reader);
        context.Publications.Add(book);
        context.Publications.Add(ebook);
        context.Publications.Add(paper2);
        context.Publications.Add(paper);
        context.Publications.Add(book1);
        context.Publications.Add(book2);
        context.Publications.Add(magazine);
        context.Publications.Add(vogue);
        context.Publications.Add(ebook2);
        context.SaveChanges();
    }
}