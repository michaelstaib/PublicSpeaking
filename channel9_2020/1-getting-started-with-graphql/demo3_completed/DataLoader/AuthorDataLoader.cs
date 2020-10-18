using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using GreenDonut;
using HotChocolate.DataLoader;

namespace Demo.Types.DataLoader
{
    public class AuthorDataLoader : BatchDataLoader<int, Author>
    {
        private readonly IDbContextFactory<BookContext> _contextFactory;

        public AuthorDataLoader(
            IBatchScheduler batchScheduler, 
            IDbContextFactory<BookContext> contextFactory) 
            : base(batchScheduler)
        {
            _contextFactory = contextFactory;
        }

        protected override async Task<IReadOnlyDictionary<int, Author>> LoadBatchAsync(
            IReadOnlyList<int> keys, 
            CancellationToken cancellationToken)
        {
            await using BookContext context = _contextFactory.CreateDbContext();

            return await context.Authors
                .Where(t => keys.Contains(t.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}