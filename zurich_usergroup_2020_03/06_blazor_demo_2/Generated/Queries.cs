using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Queries
        : global::StrawberryShake.IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            70,
            117,
            69,
            50,
            50,
            56,
            51,
            88,
            102,
            97,
            78,
            111,
            118,
            65,
            83,
            116,
            50,
            76,
            122,
            101,
            85,
            103,
            61,
            61
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            103,
            101,
            116,
            80,
            101,
            111,
            112,
            108,
            101,
            32,
            123,
            32,
            112,
            101,
            111,
            112,
            108,
            101,
            40,
            111,
            114,
            100,
            101,
            114,
            95,
            98,
            121,
            58,
            32,
            123,
            32,
            110,
            97,
            109,
            101,
            58,
            32,
            65,
            83,
            67,
            32,
            125,
            41,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            110,
            111,
            100,
            101,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            101,
            109,
            97,
            105,
            108,
            32,
            105,
            109,
            97,
            103,
            101,
            85,
            114,
            105,
            32,
            105,
            115,
            79,
            110,
            108,
            105,
            110,
            101,
            32,
            108,
            97,
            115,
            116,
            83,
            101,
            101,
            110,
            32,
            125,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query getPeople {
              people(order_by: { name: ASC }) {
                nodes {
                  id
                  name
                  email
                  imageUri
                  isOnline
                  lastSeen
                }
              }
            }";
    }
}
