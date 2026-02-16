using MichelMichels.CliSharp.Attributes;

namespace MichelMichels.VeraCryptSharp.Enums;

public enum Answer
{
    [ParameterName("")]
    None,

    [ParameterName("y")]
    Yes,

    [ParameterName("n")]
    No
}
