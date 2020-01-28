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
    public class OnReviewResultParser
        : JsonResultParserBase<IOnReview>
    {
        private readonly IValueSerializer _intSerializer;

        public OnReviewResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IOnReview ParserData(JsonElement data)
        {
            return new OnReview1
            (
                ParseOnReviewOnReview(data, "onReview")
            );

        }

        private IReview ParseOnReviewOnReview(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Review
            (
                DeserializeInt(obj, "stars")
            );
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32())!;
        }
    }
}
