var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<BookContext>(
        (s, o) => o
            .UseSqlite("Data Source=books.db")
            .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<BookContext>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
