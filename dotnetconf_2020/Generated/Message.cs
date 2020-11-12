using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Message
        : IMessage
    {
        public Message(
            string id, 
            global::Client.IParticipant sender, 
            global::Client.IParticipant recipient, 
            Direction direction, 
            string text, 
            System.DateTimeOffset sent)
        {
            Id = id;
            Sender = sender;
            Recipient = recipient;
            Direction = direction;
            Text = text;
            Sent = sent;
        }

        public string Id { get; }

        public global::Client.IParticipant Sender { get; }

        public global::Client.IParticipant Recipient { get; }

        public Direction Direction { get; }

        public string Text { get; }

        public System.DateTimeOffset Sent { get; }
    }
}
