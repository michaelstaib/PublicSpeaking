using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class StarWarsClient
        : IStarWarsClient
    {
        private const string _clientName = "StarWarsClient";

        private readonly IOperationExecutor _executor;
        private readonly IOperationStreamExecutor _streamExecutor;

        public StarWarsClient(IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
            _streamExecutor = executorPool.CreateStreamExecutor(_clientName);
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
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IResponseStream<IOnReview>> OnReviewAsync(
            Optional<Episode> episode = default,
            CancellationToken cancellationToken = default)
        {

            return _streamExecutor.ExecuteAsync(
                new OnReviewOperation { Episode = episode },
                cancellationToken);
        }

        public Task<IResponseStream<IOnReview>> OnReviewAsync(
            OnReviewOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _streamExecutor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
