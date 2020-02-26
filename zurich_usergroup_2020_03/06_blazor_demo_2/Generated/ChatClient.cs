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

        public ChatClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IPeople>> GetPeopleAsync(
            global::StrawberryShake.Optional<string> userId = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (userId.HasValue && userId.Value is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _executor.ExecuteAsync(
                new GetPeopleOperation { UserId = userId },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            global::StrawberryShake.Optional<string> userId = default,
            global::StrawberryShake.Optional<string> recipientId = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (userId.HasValue && userId.Value is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (recipientId.HasValue && recipientId.Value is null)
            {
                throw new ArgumentNullException(nameof(recipientId));
            }

            return _executor.ExecuteAsync(
                new GetPeopleAndRecipientOperation
                {
                    UserId = userId, 
                    RecipientId = recipientId
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            GetPeopleAndRecipientOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IRecipientById>> GetRecipientAsync(
            global::StrawberryShake.Optional<string> recipientId = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (recipientId.HasValue && recipientId.Value is null)
            {
                throw new ArgumentNullException(nameof(recipientId));
            }

            return _executor.ExecuteAsync(
                new GetRecipientOperation { RecipientId = recipientId },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.IRecipientById>> GetRecipientAsync(
            GetRecipientOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISignIn>> SignInAsync(
            global::StrawberryShake.Optional<global::Client.LoginInput> signIn = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (signIn.HasValue && signIn.Value is null)
            {
                throw new ArgumentNullException(nameof(signIn));
            }

            return _executor.ExecuteAsync(
                new SignInOperation { SignIn = signIn },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISignIn>> SignInAsync(
            SignInOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISignUp>> SignUpAsync(
            global::StrawberryShake.Optional<global::Client.CreateUserInput> newUser = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (newUser.HasValue && newUser.Value is null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            return _executor.ExecuteAsync(
                new SignUpOperation { NewUser = newUser },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Client.ISignUp>> SignUpAsync(
            SignUpOperation operation,
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
