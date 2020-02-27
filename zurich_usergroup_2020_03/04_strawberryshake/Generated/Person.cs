using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Demo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Person
        : IPerson
    {
        public Person(
            string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
