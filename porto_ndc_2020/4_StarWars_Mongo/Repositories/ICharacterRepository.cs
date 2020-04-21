using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Characters;

namespace StarWars.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<ICharacter> GetCharacters();

        Task<IReadOnlyDictionary<int, ICharacter>> GetCharactersAsync(IReadOnlyList<int> ids);
    }
}
