using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public interface IHasFriends
    {
        ICharacterConnection? Friends { get; }
    }
}
