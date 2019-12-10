using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    public class HasName
        : IHasName
    {
        public HasName(
            string? name)
        {
            Name = name;
        }

        public string? Name { get; }
    }
}
