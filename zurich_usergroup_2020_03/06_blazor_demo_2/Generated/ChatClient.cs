using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ChatClient
        : IChatClient
    {
        private const string _clientName = "ChatClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;
        private readonly global::StrawberryShake.IOperationStreamExecutor _streamExecutor;

        public ChatClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
            _streamExecutor = executorPool.CreateStreamExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetPeople>> GetPeopleAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetPeopleOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetMessages>> GetMessagesAsync(
            global::StrawberryShake.Optional<string> email = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (email.HasValue && email.Value is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return _executor.ExecuteAsync(
                new GetMessagesOperation { Email = email },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetMessages>> GetMessagesAsync(
            GetMessagesOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISendMessage>> SendMessageAsync(
            global::StrawberryShake.Optional<string> to = default,
            global::StrawberryShake.Optional<string> message = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (to.HasValue && to.Value is null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            if (message.HasValue && message.Value is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return _executor.ExecuteAsync(
                new SendMessageOperation
                {
                    To = to, 
                    Message = message
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISendMessage>> SendMessageAsync(
            SendMessageOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IReadMessages>> ReadMessagesAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _streamExecutor.ExecuteAsync(
                new ReadMessagesOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IReadMessages>> ReadMessagesAsync(
            ReadMessagesOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _streamExecutor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
