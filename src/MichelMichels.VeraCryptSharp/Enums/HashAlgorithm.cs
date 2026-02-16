using MichelMichels.CliSharp.Attributes;

namespace MichelMichels.VeraCryptSharp.Enums;

public enum HashAlgorithm
{
    [ParameterName("")]
    Auto,

    [ParameterName("sha256")]
    SHA256,

    [ParameterName("sha512")]
    SHA512,

    [ParameterName("whirlpool")]
    Whirlpool,

    [ParameterName("ripemd160")]
    RIPEMD160,
}