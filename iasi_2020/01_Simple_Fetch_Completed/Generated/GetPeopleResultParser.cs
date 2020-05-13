using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPeopleResultParser
        : JsonResultParserBase<IGetPeople>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;

        public GetPeopleResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
        }

        protected override IGetPeople ParserData(JsonElement data)
        {
            return new GetPeople
            (
                ParseGetPeoplePeople(data, "people")
            );

        }

        private global::Client.IPersonConnection? ParseGetPeoplePeople(
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

            return new PersonConnection
            (
                ParseGetPeoplePeopleNodes(obj, "nodes")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::Client.IPerson>? ParseGetPeoplePeopleNodes(
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
            var list = new global::Client.IPerson[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Person
                (
                    DeserializeString(element, "name"),
                    DeserializeDateTime(element, "lastSeen")
                );

            }

            return list;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString())!;
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString())!;
        }
    }
}
