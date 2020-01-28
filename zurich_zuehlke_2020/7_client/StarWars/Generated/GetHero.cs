using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class GetHero
        : IGetHero
    {
        public GetHero(
            ICharacter? hero)
        {
            Hero = hero;
        }

        public ICharacter? Hero { get; }
    }
}
