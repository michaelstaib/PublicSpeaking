using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Demo.Data;
using GreenDonut;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.DataLoader;
using HotChocolate.Types;

namespace Demo
{
    [ExtendObjectType(typeof(Book))]
    public class BookDetails
    {
        [IsProjected]
        public int GetId([Parent] Book book) => book.Id;

        public Task<string?> GetDescriptionAsync(
            [Parent] Book book,
            BookDescriptionByIdDataLoader detailsById,
            CancellationToken cancellationToken)
            => detailsById.LoadAsync(book.Id, cancellationToken);
    }

    public class BookDescriptionByIdDataLoader : BatchDataLoader<int, string?>
    {
        public BookDescriptionByIdDataLoader(IBatchScheduler batchScheduler)
            : base(batchScheduler)
        {
        }
    
        protected override async Task<IReadOnlyDictionary<int, string?>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Reading {string.Join(", ", keys)} ...");
    
            var buffer = await File.ReadAllBytesAsync("book-details.json", cancellationToken);
            var details = JsonSerializer.Deserialize<List<BookDetails>>(
                buffer, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            var map = new Dictionary<int, string?>();
            var set = new HashSet<int>(keys);
    
            foreach (BookDetails detail in details)
            {
                if (set.Contains(detail.Id))
                {
                    map[detail.Id] = detail.Description;
                }
            }
    
            return map;
        }
    
        private class BookDetails
        {
            public int Id { get; set; }
            public string Description { get; set; } = default!;
        }
    }
}