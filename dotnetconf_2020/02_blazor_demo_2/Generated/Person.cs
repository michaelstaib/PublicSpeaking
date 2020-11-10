using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Person
        : IPerson
    {
        public Person(
            string name, 
            string email, 
            bool isOnline, 
            System.Uri imageUri, 
            System.DateTimeOffset lastSeen)
        {
            Name = name;
            Email = email;
            IsOnline = isOnline;
            ImageUri = imageUri;
            LastSeen = lastSeen;
        }

        public string Name { get; }

        public string Email { get; }

        public bool IsOnline { get; }

        public System.Uri ImageUri { get; }

        public System.DateTimeOffset LastSeen { get; }
    }
}
