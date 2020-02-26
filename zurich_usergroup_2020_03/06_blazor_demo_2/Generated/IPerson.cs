using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPerson
    {
        string Id { get; }

        string Name { get; }

        string Email { get; }

        System.Uri? ImageUri { get; }

        bool IsOnline { get; }

        System.DateTimeOffset LastSeen { get; }
    }
}
