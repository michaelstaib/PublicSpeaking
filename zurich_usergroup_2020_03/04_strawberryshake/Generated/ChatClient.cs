using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Demo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ChatClient
        : IChatClient
    {
        private const string _clientName = "ChatClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;

        public ChatClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Demo.IGetMe>> GetMeAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetMeOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Demo.IGetMe>> GetMeAsync(
            GetMeOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
