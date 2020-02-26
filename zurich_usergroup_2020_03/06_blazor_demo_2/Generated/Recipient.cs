using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Recipient
        : IRecipient
    {
        public Recipient(
            global::Client.IMessageConnection? messages, 
            string id, 
            string name, 
            string email, 
            System.Uri? imageUri, 
            bool isOnline, 
            System.DateTimeOffset lastSeen)
        {
            Messages = messages;
            Id = id;
            Name = name;
            Email = email;
            ImageUri = imageUri;
            IsOnline = isOnline;
            LastSeen = lastSeen;
        }

        public global::Client.IMessageConnection? Messages { get; }

        public string Id { get; }

        public string Name { get; }

        public string Email { get; }

        public System.Uri? ImageUri { get; }

        public bool IsOnline { get; }

        public System.DateTimeOffset LastSeen { get; }
    }
}
