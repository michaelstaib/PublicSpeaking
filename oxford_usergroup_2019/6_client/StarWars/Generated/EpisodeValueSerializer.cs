using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class EpisodeValueSerializer
        : IValueSerializer
    {
        public string Name => "Episode";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(Episode);

        public Type SerializationType => typeof(string);

        public object? Serialize(object? value)
        {
            if(value is null)
            {
                return null;
            }

            var enumValue = (Episode)value;

            switch(enumValue)
            {
                case Episode.NewHope:
                    return "NEWHOPE";
                case Episode.Empire:
                    return "EMPIRE";
                case Episode.Jedi:
                    return "JEDI";
                default:
                    throw new NotSupportedException();
            }
        }

        public object? Deserialize(object? serialized)
        {
            if(serialized is null)
            {
                return null;
            }

            var stringValue = (string)serialized;

            switch(stringValue)
            {
                case "NEWHOPE":
                    return Episode.NewHope;
                case "EMPIRE":
                    return Episode.Empire;
                case "JEDI":
                    return Episode.Jedi;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
