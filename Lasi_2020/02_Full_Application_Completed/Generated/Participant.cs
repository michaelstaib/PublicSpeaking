using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Participant
        : IParticipant
    {
        public Participant(
            string name, 
            string email, 
            bool isOnline)
        {
            Name = name;
            Email = email;
            IsOnline = isOnline;
        }

        public string Name { get; }

        public string Email { get; }

        public bool IsOnline { get; }
    }
}
