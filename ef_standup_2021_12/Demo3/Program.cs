var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<BookContext>(
        (s, o) => o
            .UseSqlite("Data Source=books.db")
            .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
    
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()

    .EnableMutationConventions()

    .AddProjections()
    .AddFiltering()
    .AddSorting()
    
    .RegisterDbContext<BookContext>(kind: DbContextKind.Pooled)
    .RegisterService<ITopicEventSender>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
