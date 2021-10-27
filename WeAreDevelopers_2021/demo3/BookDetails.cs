using System.Threading.Tasks;
using Demo.Data;
using Demo.Types.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Data;
using System.Threading;

namespace Demo
{
    [ExtendObjectType(typeof(Book))]
    public class BookDetails
    {
        [IsProjected]
        public int GetId([Parent] Book book) => book.Id;

        [Parallel]
        public Task<string?> GetDescriptionAsync(
            [Parent] Book book,
            BookDescriptionByIdDataLoader detailsById,
            CancellationToken cancellationToken)
            => detailsById.LoadAsync(book.Id, cancellationToken);
    }
}
