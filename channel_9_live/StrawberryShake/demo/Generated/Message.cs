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
            string text, 
            Direction direction, 
            global::Client.IParticipant recipient, 
            global::Client.IParticipant sender, 
            System.DateTimeOffset sent)
        {
            Id = id;
            Text = text;
            Direction = direction;
            Recipient = recipient;
            Sender = sender;
            Sent = sent;
        }

        public string Id { get; }

        public string Text { get; }

        public Direction Direction { get; }

        public global::Client.IParticipant Recipient { get; }

        public global::Client.IParticipant Sender { get; }

        public System.DateTimeOffset Sent { get; }
    }
}
