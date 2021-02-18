#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageBuilder
        : global::StrawberryShake.IOperationResultBuilder<global::System.Text.Json.JsonDocument, ISendMessageResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::System.Func<global::System.Text.Json.JsonElement, global::StrawberryShake.EntityId> _extractId;
        private readonly global::StrawberryShake.IOperationResultDataFactory<ISendMessageResult> _resultDataFactory;
        private global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, Direction> _directionParser;
        private global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.String> _stringParser;
        private global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, global::System.DateTimeOffset> _dateTimeOffsetParser;
        private global::StrawberryShake.Serialization.ILeafValueParser<global::System.Boolean, global::System.Boolean> _booleanParser;

        public SendMessageBuilder(
            global::StrawberryShake.IEntityStore entityStore,
            global::System.Func<global::System.Text.Json.JsonElement, global::StrawberryShake.EntityId> extractId,
            global::StrawberryShake.IOperationResultDataFactory<ISendMessageResult> resultDataFactory,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _extractId = extractId
                 ?? throw new global::System.ArgumentNullException(nameof(extractId));
            _resultDataFactory = resultDataFactory
                 ?? throw new global::System.ArgumentNullException(nameof(resultDataFactory));
            _directionParser = serializerResolver.GetLeafValueParser<global::System.String, Direction>("Direction")
                 ?? throw new global::System.ArgumentNullException(nameof(_directionParser));
            _stringParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.String>("ID")
                 ?? throw new global::System.ArgumentNullException(nameof(_stringParser));
            _dateTimeOffsetParser = serializerResolver.GetLeafValueParser<global::System.String, global::System.DateTimeOffset>("DateTime")
                 ?? throw new global::System.ArgumentNullException(nameof(_dateTimeOffsetParser));
            _booleanParser = serializerResolver.GetLeafValueParser<global::System.Boolean, global::System.Boolean>("Boolean")
                 ?? throw new global::System.ArgumentNullException(nameof(_booleanParser));
        }

        public global::StrawberryShake.IOperationResult<ISendMessageResult> Build(global::StrawberryShake.Response<global::System.Text.Json.JsonDocument> response)
        {
            (ISendMessageResult Result, SendMessageResultInfo Info)? data = null;

            if (response.Body is not null
                && response.Body.RootElement.TryGetProperty("data", out global::System.Text.Json.JsonElement obj))
            {
                data = BuildData(obj);
            }

            return new global::StrawberryShake.OperationResult<ISendMessageResult>(
                data?.Result,
                data?.Info,
                _resultDataFactory,
                null);
        }

        private (ISendMessageResult, SendMessageResultInfo) BuildData(global::System.Text.Json.JsonElement obj)
        {
            using global::StrawberryShake.IEntityUpdateSession session = _entityStore.BeginUpdate();
            var entityIds = new global::System.Collections.Generic.HashSet<global::StrawberryShake.EntityId>();


            var resultInfo = new SendMessageResultInfo(
                DeserializeNonNullableISendMessage_SendMessage(
                    global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj, "sendMessage"),
                    entityIds),
                entityIds,
                session.Version);

            return (_resultDataFactory.Create(resultInfo), resultInfo);
        }

        private global::Demo.State.SendMessagePayloadData DeserializeNonNullableISendMessage_SendMessage(
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            var typename = obj.Value.GetProperty("__typename").GetString();

            if (typename?.Equals("SendMessagePayload", global::System.StringComparison.Ordinal) ?? false)
            {
                return new global::Demo.State.SendMessagePayloadData(
                    typename,
                    message: UpdateNonNullableISendMessage_SendMessage_MessageEntity(
                        global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "message"),
                        entityIds));
            }

            throw new global::System.NotSupportedException();
        }

        private global::StrawberryShake.EntityId UpdateNonNullableISendMessage_SendMessage_MessageEntity(
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            global::StrawberryShake.EntityId entityId = _extractId(obj.Value);
            entityIds.Add(entityId);


            if (entityId.Name.Equals("Message", global::System.StringComparison.Ordinal))
            {
                MessageEntity entity = _entityStore.GetOrCreate<MessageEntity>(entityId);
                entity.Id = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "id"));
                entity.Text = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "text"));
                entity.Direction = DeserializeNonNullableDirection(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "direction"));
                entity.Recipient = UpdateNonNullableIGetMessages_PersonByEmail_Messages_Nodes_RecipientEntity(
                    global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "recipient"),
                    entityIds);
                entity.Sender = UpdateNonNullableIGetMessages_PersonByEmail_Messages_Nodes_SenderEntity(
                    global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "sender"),
                    entityIds);
                entity.Sent = DeserializeNonNullableDateTimeOffset(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "sent"));

                return entityId;
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.String DeserializeNonNullableString(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _stringParser.Parse(obj.Value.GetString()!);
        }

        private Direction DeserializeNonNullableDirection(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _directionParser.Parse(obj.Value.GetString()!);
        }

        private global::StrawberryShake.EntityId UpdateNonNullableIGetMessages_PersonByEmail_Messages_Nodes_RecipientEntity(
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            global::StrawberryShake.EntityId entityId = _extractId(obj.Value);
            entityIds.Add(entityId);


            if (entityId.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                PersonEntity entity = _entityStore.GetOrCreate<PersonEntity>(entityId);
                entity.Name = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "name"));
                entity.Email = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "email"));
                entity.IsOnline = DeserializeNonNullableBoolean(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "isOnline"));

                return entityId;
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.Boolean DeserializeNonNullableBoolean(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _booleanParser.Parse(obj.Value.GetBoolean()!);
        }

        private global::StrawberryShake.EntityId UpdateNonNullableIGetMessages_PersonByEmail_Messages_Nodes_SenderEntity(
            global::System.Text.Json.JsonElement? obj,
            global::System.Collections.Generic.ISet<global::StrawberryShake.EntityId> entityIds)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            global::StrawberryShake.EntityId entityId = _extractId(obj.Value);
            entityIds.Add(entityId);


            if (entityId.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                PersonEntity entity = _entityStore.GetOrCreate<PersonEntity>(entityId);
                entity.Name = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "name"));
                entity.Email = DeserializeNonNullableString(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "email"));
                entity.IsOnline = DeserializeNonNullableBoolean(global::StrawberryShake.Transport.Http.JsonElementExtensions.GetPropertyOrNull(obj.Value, "isOnline"));

                return entityId;
            }

            throw new global::System.NotSupportedException();
        }

        private global::System.DateTimeOffset DeserializeNonNullableDateTimeOffset(global::System.Text.Json.JsonElement? obj)
        {
            if (!obj.HasValue)
            {
                throw new global::System.ArgumentNullException();
            }

            return _dateTimeOffsetParser.Parse(obj.Value.GetString()!);
        }
    }
}
