using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using StarWars.Repositories;

namespace StarWars.Characters
{
    [ExtendObjectType(Name = "Query")]
    public class CharacterQueries
    {
        /// <summary>
        /// Retrieve a hero by a particular Star Wars episode.
        /// </summary>
        /// <param name="episode">The episode to look up by.</param>
        /// <param name="charaterById"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The character.</returns>
        public Task<ICharacter> GetHeroAsync(
            Episode episode,
            CharacterDataLoader charaterById,
            CancellationToken cancellationToken)
        {
            if (episode == Episode.Empire)
            {
                return charaterById.LoadAsync(1000, cancellationToken);
            }
            return charaterById.LoadAsync(2001, cancellationToken);
        }


        /// <summary>
        /// Gets all character.
        /// </summary>
        /// <param name="repository"></param>
        /// <returns>The character.</returns>
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ICharacter> GetCharacters(
            [Service]ICharacterRepository repository) =>
            repository.GetCharacters();
    }
}
