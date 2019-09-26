using CliSharp.Core;
using System.Collections.Generic;
using VeraCryptSharp.Enums;

namespace VeraCryptSharp
{
    public interface IVeraCrypt
    {
        void Mount(string filePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool isSilent = true);
        void MountSecure(string filePath, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool useSecureDesktop = false);
        void Dismount(string driveLetter, bool isSilent = true);
        void DismountAll();
        void Execute(IEnumerable<CommandLineSwitch> switches);
    }
}
