using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StarWars.Characters;

namespace StarWars.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IMongoCollection<ICharacter> _characters;
        private readonly IMongoCollection<Starship> _starships;

        public CharacterRepository(
            IMongoCollection<ICharacter> characters,
            IMongoCollection<Starship> starships)
        {
            _characters = characters;
            _starships = starships;
        }

        public IQueryable<ICharacter> GetCharacters() => _characters.AsQueryable();

        public async Task<IReadOnlyDictionary<int, ICharacter>> GetCharacters(IReadOnlyList<int> ids)
        {
            FilterDefinition<ICharacter> filter = Builders<ICharacter>.Filter.Or(
                ids.Select(id => Builders<ICharacter>.Filter.Eq(t => t.Id, id)));
            List<ICharacter> characters = await _characters.Find(filter).ToListAsync();
            return characters.ToDictionary(t => t.Id);
        }

        private static IEnumerable<ICharacter> CreateCharacters()
        {
            yield return new Human
            (
                1000,
                "Luke Skywalker",
                new[] { 1002, 1003, 2000, 2001 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi },
                "Tatooine"
            );

            yield return new Human
            (
                1001,
                "Darth Vader",
                new[] { 1004 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi },
                "Tatooine"
            );

            yield return new Human
            (
                1002,
                "Han Solo",
                new[] { 1000, 1003, 2001 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi }
            );

            yield return new Human
            (
                1003,
                "Leia Organa",
                new[] { 1000, 1002, 2000, 2001 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi },
                "Alderaan"
            );

            yield return new Human
            (
                1004,
                "Wilhuff Tarkin",
                new[] { 1001 },
                new[] { Episode.NewHope }
            );

            yield return new Droid
            (
                2000,
                "C-3PO",
                new[] { 1000, 1002, 1003, 2001 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi },
                "Protocol"
            );

            yield return new Droid
            (
                2001,
                "R2-D2",
                new[] { 1000, 1002, 1003 },
                new[] { Episode.NewHope, Episode.Empire, Episode.Jedi },
                "Astromech"
            );
        }
    }
}
