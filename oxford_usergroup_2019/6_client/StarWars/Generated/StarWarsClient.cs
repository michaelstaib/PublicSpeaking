using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class StarWarsClient
        : IStarWarsClient
    {
        private readonly IOperationExecutor _executor;
        private readonly IOperationStreamExecutor _streamExecutor;

        public StarWarsClient(IOperationExecutor executor, IOperationStreamExecutor streamExecutor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _streamExecutor = streamExecutor ?? throw new ArgumentNullException(nameof(streamExecutor));
        }

        public Task<IOperationResult<IGetHero>> GetHeroAsync(
            Optional<Episode?> episode = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetHeroOperation { Episode = episode },
                cancellationToken);
        }

        public Task<IOperationResult<IGetHero>> GetHeroAsync(
            GetHeroOperation operation,
            CancellationToken cancellationToken = default)
        {
            if(operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IResponseStream<IOnNewReview>> OnNewReviewAsync(
            Optional<Episode?> episode = default,
            CancellationToken cancellationToken = default)
        {

            return _streamExecutor.ExecuteAsync(
                new OnNewReviewOperation { Episode = episode },
                cancellationToken);
        }

        public Task<IResponseStream<IOnNewReview>> OnNewReviewAsync(
            OnNewReviewOperation operation,
            CancellationToken cancellationToken = default)
        {
            if(operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _streamExecutor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
