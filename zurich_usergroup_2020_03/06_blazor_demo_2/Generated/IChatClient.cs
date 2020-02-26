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
        Task<IOperationResult<global::Client.IPeople>> GetPeopleAsync(
            Optional<string> userId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            Optional<string> userId = default,
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            GetPeopleAndRecipientOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IRecipientById>> GetRecipientAsync(
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IRecipientById>> GetRecipientAsync(
            GetRecipientOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISignIn>> SignInAsync(
            Optional<global::Client.LoginInput> signIn = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISignIn>> SignInAsync(
            SignInOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISignUp>> SignUpAsync(
            Optional<global::Client.CreateUserInput> newUser = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.ISignUp>> SignUpAsync(
            SignUpOperation operation,
            CancellationToken cancellationToken = default);
    }
}
