using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IStarWarsClient
    {
        Task<IOperationResult<IGetHero>> GetHeroAsync(
            Optional<Episode?> episode = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetHero>> GetHeroAsync(
            GetHeroOperation operation,
            CancellationToken cancellationToken = default);

        Task<IResponseStream<IOnReview>> OnReviewAsync(
            Optional<Episode> episode = default,
            CancellationToken cancellationToken = default);

        Task<IResponseStream<IOnReview>> OnReviewAsync(
            OnReviewOperation operation,
            CancellationToken cancellationToken = default);
    }
}
