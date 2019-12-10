using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public interface IStarWarsClient
    {
        Task<IOperationResult<IGetHero>> GetHeroAsync(
            Optional<Episode?> episode = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetHero>> GetHeroAsync(
            GetHeroOperation operation,
            CancellationToken cancellationToken = default);

        Task<IResponseStream<IOnNewReview>> OnNewReviewAsync(
            Optional<Episode?> episode = default,
            CancellationToken cancellationToken = default);

        Task<IResponseStream<IOnNewReview>> OnNewReviewAsync(
            OnNewReviewOperation operation,
            CancellationToken cancellationToken = default);
    }
}
