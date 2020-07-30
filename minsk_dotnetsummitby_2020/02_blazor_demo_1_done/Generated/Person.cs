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
            System.DateTimeOffset lastSeen)
        {
            Name = name;
            LastSeen = lastSeen;
        }

        public string Name { get; }

        public System.DateTimeOffset LastSeen { get; }
    }
}
