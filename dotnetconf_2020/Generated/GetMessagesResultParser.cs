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
    public partial class GetMessagesResultParser
        : JsonResultParserBase<IGetMessages>
    {
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _directionSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _booleanSerializer;

        public GetMessagesResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
            _directionSerializer = serializerResolver.Get("Direction");
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _booleanSerializer = serializerResolver.Get("Boolean");
        }

        protected override IGetMessages ParserData(JsonElement data)
        {
            return new GetMessages
            (
                ParseGetMessagesPersonByEmail(data, "personByEmail")
            );

        }

        private global::Client.IPerson1 ParseGetMessagesPersonByEmail(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Person1
            (
                ParseGetMessagesPersonByEmailMessages(obj, "messages")
            );
        }

        private global::Client.IMessageConnection ParseGetMessagesPersonByEmailMessages(
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

            return new MessageConnection
            (
                ParseGetMessagesPersonByEmailMessagesNodes(obj, "nodes")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::Client.IMessage> ParseGetMessagesPersonByEmailMessagesNodes(
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
            var list = new global::Client.IMessage[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Message
                (
                    DeserializeID(element, "id"),
                    ParseGetMessagesPersonByEmailMessagesNodesSender(element, "sender"),
                    ParseGetMessagesPersonByEmailMessagesNodesRecipient(element, "recipient"),
                    DeserializeDirection(element, "direction"),
                    DeserializeString(element, "text"),
                    DeserializeDateTime(element, "sent")
                );

            }

            return list;
        }

        private global::Client.IParticipant ParseGetMessagesPersonByEmailMessagesNodesRecipient(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Participant
            (
                DeserializeString(obj, "name"),
                DeserializeString(obj, "email"),
                DeserializeBoolean(obj, "isOnline")
            );
        }

        private global::Client.IParticipant ParseGetMessagesPersonByEmailMessagesNodesSender(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Participant
            (
                DeserializeString(obj, "name"),
                DeserializeString(obj, "email"),
                DeserializeBoolean(obj, "isOnline")
            );
        }

        private string DeserializeID(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_iDSerializer.Deserialize(value.GetString());
        }

        private Direction DeserializeDirection(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (Direction)_directionSerializer.Deserialize(value.GetString());
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }
        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
        }
    }
}
