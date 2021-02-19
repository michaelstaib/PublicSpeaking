#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsers_People_Nodes_PersonFromPersonEntityMapper
        : global::StrawberryShake.IEntityMapper<PersonEntity, GetUsers_People_Nodes_Person>
    {
        public GetUsers_People_Nodes_Person Map(PersonEntity entity)
        {
            return new GetUsers_People_Nodes_Person(
                entity.Name,
                entity.Email,
                entity.IsOnline,
                entity.LastSeen,
                entity.ImageUri);
        }
    }
}
