using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPeople
        : IGetPeople
    {
        public GetPeople(
            global::Client.IPersonConnection people)
        {
            People = people;
        }

        public global::Client.IPersonConnection People { get; }
    }
}
