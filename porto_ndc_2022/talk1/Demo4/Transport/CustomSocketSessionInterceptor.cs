using System.Security.Claims;
using System.Text;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore.Subscriptions.Protocols;
using HotChocolate.Execution;

namespace Demo.Transport;

public sealed class CustomSocketSessionInterceptor : DefaultSocketSessionInterceptor
{
    private readonly IDbContextFactory<AssetContext> _contextFactory;

    public CustomSocketSessionInterceptor(IDbContextFactory<AssetContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public override async ValueTask<ConnectionStatus> OnConnectAsync(
        ISocketSession session,
        IOperationMessagePayload connectionInitMessage,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var payload = connectionInitMessage.As<Dictionary<string, string?>>();

            if (payload is not null &&
                payload.TryGetValue("Authorization", out var value) &&
                value is string s)
            {
                var credentialBytes = Convert.FromBase64String(s.Split(' ', 2).Last());
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                string username = credentials[0];

                session.Connection.HttpContext.Items.TryAdd("username", username);
                session.Connection.HttpContext.User.AddIdentity(new ClaimsIdentity(new[] { new Claim("sub", username) }, "basic"));

                await using var assetContext = await _contextFactory.CreateDbContextAsync(cancellationToken);
                if (!await assetContext.Users.AnyAsync(t => t.Name == username, cancellationToken))
                {
                    assetContext.Users.Add(new User { Name = username });
                    await assetContext.SaveChangesAsync(cancellationToken);
                }
            }
        }
        catch
        {
            return ConnectionStatus.Reject();
        }

        return await base.OnConnectAsync(session, connectionInitMessage, cancellationToken);
    }

    public override ValueTask OnRequestAsync(
        ISocketSession session,
        string operationSessionId,
        IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken = default)
    {
        if (session.Connection.HttpContext.Items.TryGetValue("username", out var value) &&
            value is string username)
        {
            requestBuilder.SetGlobalState("username", username);
        }

        return base.OnRequestAsync(session, operationSessionId, requestBuilder, cancellationToken);
    }

    public override ValueTask OnPongAsync(ISocketSession session, IOperationMessagePayload pongMessage, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Pong");
        return base.OnPongAsync(session, pongMessage, cancellationToken);
    }

    public override ValueTask OnCloseAsync(ISocketSession session, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Closed socket");
        return base.OnCloseAsync(session, cancellationToken);
    }
}