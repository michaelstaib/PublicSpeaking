using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace Demo.Transport;

public sealed class CustomHttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public CustomHttpRequestInterceptor(IDbContextFactory<AssetContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public override async ValueTask OnCreateAsync(
        HttpContext context,
        IRequestExecutor requestExecutor,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        requestBuilder.SetGlobalState("username", null);

        if (context.Request.Headers.TryGetValue("Authorization", out var value))
        {
            if (AuthenticationHeaderValue.Parse(value) is { Parameter: { } parameters })
            {
                var credentialBytes = Convert.FromBase64String(parameters);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                string username = credentials[0];

                context.User.AddIdentity(new ClaimsIdentity(new[] { new Claim("sub", credentials[0]) }, "basic"));
                requestBuilder.SetGlobalState("username", credentials[0]);

                await using var assetContext = await _contextFactory.CreateDbContextAsync(cancellationToken);
                if (!await assetContext.Users.AnyAsync(t => t.Name == username, cancellationToken))
                {
                    assetContext.Users.Add(new User { Name = username });
                    await assetContext.SaveChangesAsync(cancellationToken);
                }
            }
        }

        await base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}
