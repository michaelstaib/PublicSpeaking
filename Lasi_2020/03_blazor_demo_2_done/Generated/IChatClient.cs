using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IChatClient
    {
        Task<IOperationResult<global::Client.IGetPeople>> GetPeopleAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetMessages>> GetMessagesAsync(
            Optional<string> email = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetMessages>> GetMessagesAsync(
            GetMessagesOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISendMessage>> SendMessageAsync(
            Optional<string> to = default,
            Optional<string> message = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISendMessage>> SendMessageAsync(
            SendMessageOperation operation,
            CancellationToken cancellationToken = default);

        global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IReadMessages>> ReadMessagesAsync(
            CancellationToken cancellationToken = default);

        global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IReadMessages>> ReadMessagesAsync(
            ReadMessagesOperation operation,
            CancellationToken cancellationToken = default);
    }
}
