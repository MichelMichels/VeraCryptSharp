using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp.Enums;

namespace VeraCryptSharp
{
    public interface IVeraCrypt
    {
        void Mount(string filePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "", bool isSilent = true);
        void Dismount(string driveLetter, bool isSilent = true);
        void DismountAll();
    }
}
