using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp.Attributes;

namespace VeraCryptSharp.Enums
{
    public enum HashAlgorithm
    {
        [ArgumentName("")]
        Auto,

        [ArgumentName("sha256")]
        SHA256,

        [ArgumentName("sha512")]
        SHA512,

        [ArgumentName("whirlpool")]
        Whirlpool,

        [ArgumentName("ripemd160")]
        RIPEMD160,
    }   
}