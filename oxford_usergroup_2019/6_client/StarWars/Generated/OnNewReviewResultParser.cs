using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;

namespace StarWarsClientDemo
{
    public class OnNewReviewResultParser
        : JsonResultParserBase<IOnNewReview>
    {
        private readonly IValueSerializer _intSerializer;

        public OnNewReviewResultParser(IValueSerializerResolver serializerResolver)
        {
            if(serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.GetValueSerializer("Int");
        }

        protected override IOnNewReview ParserData(JsonElement data)
        {
            return new OnNewReview
            (
                ParseOnNewReviewOnReview(data, "onReview")
            );

        }

        private IReview ParseOnNewReviewOnReview(
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
