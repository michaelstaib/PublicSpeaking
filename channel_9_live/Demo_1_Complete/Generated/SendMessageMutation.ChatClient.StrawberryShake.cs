#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageMutation
    {
        private readonly global::StrawberryShake.IOperationExecutor<ISendMessageResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter;

        public SendMessageMutation(
            global::StrawberryShake.IOperationExecutor<ISendMessageResult> operationExecutor,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
        }

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<ISendMessageResult>> ExecuteAsync(
            global::System.String email,
            global::System.String text,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(
                email,
                text);
            
            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<ISendMessageResult>> Watch(
            global::System.String email,
            global::System.String text,
            global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(
                email,
                text);
            return _operationExecutor.Watch(request, strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(
            global::System.String email,
            global::System.String text)
        {
            var arguments = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();
            arguments.Add("email", FormatEmail(email));
            arguments.Add("text", FormatText(text));

            return new global::StrawberryShake.OperationRequest(
                "SendMessage",
                SendMessageMutationDocument.Instance,
                arguments);
        }

        private global::System.Object? FormatEmail(global::System.String value)
        {
            if (value == default)
            {
                return null;
            }

            return _stringFormatter.Format(value);
        }

        private global::System.Object? FormatText(global::System.String value)
        {
            if (value == default)
            {
                return null;
            }

            return _stringFormatter.Format(value);
        }
    }
}
