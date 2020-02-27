using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Demo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMe
        : IGetMe
    {
        public GetMe(
            global::Demo.IPerson me)
        {
            Me = me;
        }

        public global::Demo.IPerson Me { get; }
    }
}
