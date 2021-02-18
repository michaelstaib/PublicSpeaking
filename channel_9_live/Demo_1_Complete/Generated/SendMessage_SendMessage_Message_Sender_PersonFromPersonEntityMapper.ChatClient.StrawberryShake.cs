#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessage_SendMessage_Message_Sender_PersonFromPersonEntityMapper
        : global::StrawberryShake.IEntityMapper<PersonEntity, SendMessage_SendMessage_Message_Sender_Person>
    {
        public SendMessage_SendMessage_Message_Sender_Person Map(PersonEntity entity)
        {
            return new SendMessage_SendMessage_Message_Sender_Person(
                entity.Name,
                entity.Email,
                entity.IsOnline);
        }
    }
}
