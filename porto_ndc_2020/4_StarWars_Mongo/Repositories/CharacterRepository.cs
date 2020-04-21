using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using StarWars.Characters;

namespace StarWars.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IMongoCollection<ICharacter> _characters;

        public CharacterRepository(IMongoCollection<ICharacter> characters)
        {
            _characters = characters;
        }

        public IQueryable<ICharacter> GetCharacters() => _characters.AsQueryable();

        public async Task<IReadOnlyDictionary<int, ICharacter>> GetCharactersAsync(IReadOnlyList<int> ids)
        {
            FilterDefinition<ICharacter> filter = Builders<ICharacter>.Filter.Or(
                ids.Select(id => Builders<ICharacter>.Filter.Eq(t => t.Id, id)));
            List<ICharacter> characters = await _characters.Find(filter).ToListAsync();
            return characters.ToDictionary(t => t.Id);
        }
    }

    public class ContentTypeDiscriminatorConvention : IDiscriminatorConvention
    {
        public string ElementName
        {
            get { return "_contentType"; }
        }

        public Type GetActualType(IBsonReader bsonReader, Type nominalType)
        {
            var bookmark = bsonReader.GetBookmark();
            bsonReader.ReadStartDocument();
            
            if (bsonReader.FindElement("PrimaryFunction"))
            {
                bsonReader.ReturnToBookmark(bookmark);
                return typeof(Droid);
            }

            bsonReader.ReturnToBookmark(bookmark);
            bsonReader.ReadStartDocument();

            if (bsonReader.FindElement("HomePlanet"))
            {
                bsonReader.ReturnToBookmark(bookmark);
                return typeof(Droid);
            }

            throw new NotSupportedException();
        }

        public MongoDB.Bson.BsonValue GetDiscriminator(Type nominalType, Type actualType)
        {
            return actualType.Name;
        }
    }
}
