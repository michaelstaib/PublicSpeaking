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
            global::StrawberryShake.Optional<string> email = default,
            global::StrawberryShake.Optional<string> text = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (email.HasValue && email.Value is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (text.HasValue && text.Value is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return _executor.ExecuteAsync(
                new SendMessageOperation
                {
                    Email = email, 
                    Text = text
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

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IOnMessage>> OnMessageAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _streamExecutor.ExecuteAsync(
                new OnMessageOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::Client.IOnMessage>> OnMessageAsync(
            OnMessageOperation operation,
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
