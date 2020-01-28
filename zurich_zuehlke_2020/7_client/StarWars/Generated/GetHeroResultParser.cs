using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class GetHeroResultParser
        : JsonResultParserBase<IGetHero>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetHeroResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IGetHero ParserData(JsonElement data)
        {
            return new GetHero
            (
                ParseGetHeroHero(data, "hero")
            );

        }

        private ICharacter? ParseGetHeroHero(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new Character
            (
                DeserializeNullableString(obj, "name"),
                ParseGetHeroHeroFriends(obj, "friends")
            );
        }

        private ICharacterConnection? ParseGetHeroHeroFriends(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new CharacterConnection
            (
                ParseGetHeroHeroFriendsNodes(obj, "nodes")
            );
        }

        private IReadOnlyList<IHasName>? ParseGetHeroHeroFriendsNodes(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new IHasName[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new HasName
                (
                    DeserializeNullableString(element, "name")
                );

            }

            return list;
        }

        private string? DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string?)_stringSerializer.Deserialize(value.GetString())!;
        }
    }
}
