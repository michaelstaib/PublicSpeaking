#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessages_PersonByEmail_Person
        : IGetMessages_PersonByEmail_Person
    {
        public GetMessages_PersonByEmail_Person(IGetMessages_PersonByEmail_Messages? messages)
        {
            Messages = messages;
        }

        public IGetMessages_PersonByEmail_Messages? Messages { get; } = default!;
    }
}
