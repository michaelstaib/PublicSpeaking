using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
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
