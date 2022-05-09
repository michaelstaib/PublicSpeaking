using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using HotChocolate.Diagnostics;
using HotChocolate.Execution.Options;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var api = ResourceBuilder.CreateEmpty()
    .AddService("Coin-API", "Demo", "2.0.0")
    .AddAttributes(new KeyValuePair<string, object>[]
    {
        new("deployment.environment", "development"),
        new("telemetry.sdk.name", "dotnet"),
        new("telemetry.sdk.version", "6.0.0")
    });

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddCors()
    .AddHelperServices();

builder.Services
    .AddPooledDbContextFactory<AssetContext>(o => o.UseSqlite("Data Source=assets.db"));

builder.Services
    .AddHttpClient("PriceInfoService", c => c.BaseAddress = new("https://ccc-workshop-eu-functions.azurewebsites.net"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()
    .AddSubscriptionType()
    .AddAssetTypes()
    .AddType<UploadType>()
    .AddGlobalObjectIdentification()
    .AddMutationConventions()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .AddInstrumentation(o =>
    {
        o.RenameRootActivity = true;
        o.IncludeDocument = true;
    })
    .ModifyRequestOptions(o =>
    {
        o.Complexity.Enable = true;
        o.Complexity.MaximumAllowed = 5;
    })
    .RegisterDbContext<AssetContext>(DbContextKind.Pooled)
    .InitializeOnStartup();

builder.Services.AddSingleton<ActivityEnricher, CustomActivityEnricher>();

builder.Services.AddOpenTelemetryTracing(
    b =>
    {
        b.AddHttpClientInstrumentation();
        b.AddAspNetCoreInstrumentation();
        b.AddHotChocolateInstrumentation();
        b.SetResourceBuilder(api);
        b.AddOtlpExporter(c =>
        {
            c.Endpoint = new Uri("https://ndc-demo.apm.westeurope.azure.elastic-cloud.com");
            c.Headers = Constants.Headers;
        });
    });

builder.Services.AddOpenTelemetryMetrics(
    b =>
    {
        b.AddHttpClientInstrumentation();
        b.AddAspNetCoreInstrumentation();
        b.SetResourceBuilder(api);
        b.AddOtlpExporter(c =>
        {
            c.Endpoint = new Uri("https://ndc-demo.apm.westeurope.azure.elastic-cloud.com");
            c.Headers = Constants.Headers;
        });
    });

Meter meter = new Meter("Foo.Bar");



var app = builder.Build();

app.UseWebSockets();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseStaticFiles();
app.MapGraphQL();

app.Run();

