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
            Direction direction, 
            global::Client.IParticipant recipient, 
            global::Client.IParticipant sender, 
            System.DateTimeOffset sent, 
            string text)
        {
            Id = id;
            Direction = direction;
            Recipient = recipient;
            Sender = sender;
            Sent = sent;
            Text = text;
        }

        public string Id { get; }

        public Direction Direction { get; }

        public global::Client.IParticipant Recipient { get; }

        public global::Client.IParticipant Sender { get; }

        public System.DateTimeOffset Sent { get; }

        public string Text { get; }
    }
}
