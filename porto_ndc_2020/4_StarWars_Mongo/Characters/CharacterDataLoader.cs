using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.DataLoader;
using StarWars.Repositories;

namespace StarWars.Characters
{
    public class CharacterDataLoader : BatchDataLoader<int, ICharacter>
    {
        private readonly ICharacterRepository _repository;

        public CharacterDataLoader(ICharacterRepository repository)
        {
            _repository = repository;
        }

        protected override Task<IReadOnlyDictionary<int, ICharacter>> LoadBatchAsync(
            IReadOnlyList<int> keys, 
            CancellationToken cancellationToken) =>
            _repository.GetCharactersAsync(keys);
    }
}
