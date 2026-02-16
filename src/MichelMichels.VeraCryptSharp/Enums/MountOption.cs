using MichelMichels.CliSharp.Attributes;

namespace MichelMichels.VeraCryptSharp.Enums;

public enum MountOption
{
    [ParameterName("ro")]
    ReadOnly,

    [ParameterName("rm")]
    Removable,

    [ParameterName("ts")]
    DoNotPreserveTimestamp,

    [ParameterName("sm")]
    SystemEncryption,

    [ParameterName("bk")]
    EmbeddedBackupHeader,

    [ParameterName("recovery")]
    Recovery,

    [ParameterName("noattach")]
    NoAttach,
}
