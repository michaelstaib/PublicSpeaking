#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsersResult
        : IGetUsersResult
    {
        public GetUsersResult(IGetUsers_People? people)
        {
            People = people;
        }

        public IGetUsers_People? People { get; } = default!;
    }
}
