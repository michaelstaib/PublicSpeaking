using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Demo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IChatClient
    {
        Task<IOperationResult<global::Demo.IGetMe>> GetMeAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Demo.IGetMe>> GetMeAsync(
            GetMeOperation operation,
            CancellationToken cancellationToken = default);
    }
}
