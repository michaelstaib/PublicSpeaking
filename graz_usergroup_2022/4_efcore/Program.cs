var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<SchoolContext>(o => o.UseSqlite("Data Source=chat.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddMutationConventions()
    .AddInMemorySubscriptions()
    .RegisterDbContext<SchoolContext>(DbContextKind.Pooled)
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();
