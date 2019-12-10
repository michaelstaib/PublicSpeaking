using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Character
        : ICharacter
    {
        public Character(
            string? name, 
            ICharacterConnection? friends)
        {
            Name = name;
            Friends = friends;
        }

        public string? Name { get; }

        public ICharacterConnection? Friends { get; }
    }
}
