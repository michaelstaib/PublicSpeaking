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
        Task<IOperationResult<global::Client.IGetPersons>> GetPersonsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Client.IGetPersons>> GetPersonsAsync(
            GetPersonsOperation operation,
            CancellationToken cancellationToken = default);
    }
}
