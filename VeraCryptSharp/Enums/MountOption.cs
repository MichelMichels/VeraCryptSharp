using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp.Attributes;

namespace VeraCryptSharp.Enums
{    
    public enum MountOption 
    {
        [ArgumentName("ro")]
        ReadOnly,

        [ArgumentName("rm")]
        Removable,

        [ArgumentName("ts")]
        DoNotPreserveTimestamp,

        [ArgumentName("sm")]
        SystemEncryption,

        [ArgumentName("bk")]
        EmbeddedBackupHeader,

        [ArgumentName("recovery")]
        Recovery,

        [ArgumentName("noattach")]
        NoAttach,
    }
}
