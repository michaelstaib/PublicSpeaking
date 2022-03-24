var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPooledDbContextFactory<SchoolContext>(o => o.UseSqlite("Data Source=chat.db"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
