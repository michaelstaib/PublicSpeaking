using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class CharacterConnection
        : ICharacterConnection
    {
        public CharacterConnection(
            IReadOnlyList<IHasName>? nodes)
        {
            Nodes = nodes;
        }

        public IReadOnlyList<IHasName>? Nodes { get; }
    }
}
