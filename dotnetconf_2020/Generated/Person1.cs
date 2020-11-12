using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Person1
        : IPerson1
    {
        public Person1(
            global::Client.IMessageConnection messages)
        {
            Messages = messages;
        }

        public global::Client.IMessageConnection Messages { get; }
    }
}
