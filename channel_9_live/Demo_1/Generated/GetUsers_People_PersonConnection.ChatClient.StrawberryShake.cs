#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsers_People_PersonConnection
        : IGetUsers_People_PersonConnection
    {
        public GetUsers_People_PersonConnection(global::System.Collections.Generic.IReadOnlyList<IGetUsers_People_Nodes?>? nodes)
        {
            Nodes = nodes;
        }

        public global::System.Collections.Generic.IReadOnlyList<IGetUsers_People_Nodes?>? Nodes { get; } = default!;
    }
}
