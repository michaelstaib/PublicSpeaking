var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<BookContext>(
        (s, o) => o
            .UseSqlite("Data Source=books.db")
            .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
    .AddGraphQLServer()
    .AddInterfaceType<Publication>()
    .AddType<Ebook>()
    .AddType<Paper>()
    .AddType<Magazine>()
    .AddType<Book>()
    .AddQueryType<Query>()
    .AddTypeExtension<MagazineInfo>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<BookContext>(kind: DbContextKind.Pooled);

var app = builder.Build();

app.Services.SeedData();

app.MapGraphQL();

app.Run();