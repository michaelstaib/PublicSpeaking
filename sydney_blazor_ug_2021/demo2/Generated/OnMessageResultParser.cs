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
    public partial class OnMessageResultParser
        : JsonResultParserBase<IOnMessage>
    {
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _directionSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _booleanSerializer;

        public OnMessageResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
            _directionSerializer = serializerResolver.Get("Direction");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _stringSerializer = serializerResolver.Get("String");
            _booleanSerializer = serializerResolver.Get("Boolean");
        }

        protected override IOnMessage ParserData(JsonElement data)
        {
            return new OnMessage
            (
                ParseOnMessageMessage(data, "message")
            );

        }

        private global::Client.IMessage ParseOnMessageMessage(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Message
            (
                DeserializeID(obj, "id"),
                DeserializeDirection(obj, "direction"),
                ParseOnMessageMessageSender(obj, "sender"),
                ParseOnMessageMessageRecipient(obj, "recipient"),
                DeserializeDateTime(obj, "sent"),
                DeserializeString(obj, "text")
            );
        }

        private global::Client.IParticipant ParseOnMessageMessageRecipient(
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

        private global::Client.IParticipant ParseOnMessageMessageSender(
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
            return (string)_iDSerializer.Deserialize(value.GetString())!;
        }

        private Direction DeserializeDirection(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (Direction)_directionSerializer.Deserialize(value.GetString())!;
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString())!;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString())!;
        }
        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean())!;
        }
    }
}
