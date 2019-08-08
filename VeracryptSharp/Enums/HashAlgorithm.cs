using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Enums
{
    public enum HashAlgorithm
    {
        Auto,
        SHA256,
        SHA512,
        Whirlpool,
        RIPEMD160,
    }

    // sha256, sha-256, sha512, sha-512, whirlpool, ripemd160 and ripemd-160
    public static class HashAlgorithmExtensions
    {
        public static string ToFriendlyString(this HashAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithm.Auto:
                    return "";
                case HashAlgorithm.SHA256:
                    return "sha256";
                case HashAlgorithm.SHA512:
                    return "sha512";
                case HashAlgorithm.Whirlpool:
                    return "whirlpool";
                case HashAlgorithm.RIPEMD160:
                    return "ripemd160";
                default:
                    return "Get your damn dirty hands off me you FILTHY APE!";
            }
        }
    }
}
