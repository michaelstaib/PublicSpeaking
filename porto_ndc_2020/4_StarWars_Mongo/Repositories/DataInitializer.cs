using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using StarWars.Characters;

namespace StarWars.Repositories
{
    public class DataInitializer
    {
        private readonly IMongoCollection<ICharacter> _characters;

        public DataInitializer(IMongoCollection<ICharacter> characters)
        {
            _characters = characters;
        }

        public async Task InitializeAsync()
        {
            if (!await _characters.AsQueryable().AnyAsync())
            {
                await _characters.InsertManyAsync(CreateCharacters());
            }
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
