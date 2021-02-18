#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessages_Message_Recipient_PersonFromPersonEntityMapper
        : global::StrawberryShake.IEntityMapper<PersonEntity, ReadMessages_Message_Recipient_Person>
    {
        public ReadMessages_Message_Recipient_Person Map(PersonEntity entity)
        {
            return new ReadMessages_Message_Recipient_Person(
                entity.Name,
                entity.Email,
                entity.IsOnline);
        }
    }
}
