#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper
        : global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Sender_Person>
    {
        public GetMessages_PersonByEmail_Messages_Nodes_Sender_Person Map(PersonEntity entity)
        {
            return new GetMessages_PersonByEmail_Messages_Nodes_Sender_Person(
                entity.Name,
                entity.Email,
                entity.IsOnline);
        }
    }
}
