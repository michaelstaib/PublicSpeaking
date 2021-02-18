#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesResult
        : IGetMessagesResult
    {
        public GetMessagesResult(IGetMessages_PersonByEmail personByEmail)
        {
            PersonByEmail = personByEmail;
        }

        public IGetMessages_PersonByEmail PersonByEmail { get; }
    }
}
