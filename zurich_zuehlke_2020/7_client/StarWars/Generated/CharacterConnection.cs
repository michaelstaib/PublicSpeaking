using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
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
