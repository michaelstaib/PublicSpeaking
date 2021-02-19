#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DirectionSerializer
        : global::StrawberryShake.Serialization.IInputValueFormatter
        , global::StrawberryShake.Serialization.ILeafValueParser<global::System.String, Direction>
    {
        public global::System.String TypeName => "Direction";

        public Direction Parse(global::System.String serializedValue)
        {
            return serializedValue switch
            {
                "INCOMING" => Direction.Incoming,
                "OUTGOING" => Direction.Outgoing,
                _ => throw new global::StrawberryShake.GraphQLClientException()
            };
        }

        public object Format(global::System.Object? runtimeValue)
        {
            return runtimeValue switch
            {
                Direction.Incoming => "INCOMING",
                Direction.Outgoing => "OUTGOING",
                _ => throw new global::StrawberryShake.GraphQLClientException()
            };
        }
    }
}
