using System;
using System.Diagnostics;
using CommandLine;
using VeraCryptSharp.Enums;

namespace VeraCryptSharp
{
    public class VeraCrypt : IVeraCrypt
    {
        private readonly string executablePath;
            
        public VeraCrypt(string executablePath)
        {
            this.executablePath = executablePath;              
        }

        public void Mount(string filePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "", bool isSilent = true)
        {
            Execute(new Options
            {
                Volume = filePath,
                HashAlgorithm = hashAlgorithm,
                DriveLetter = driveLetter,
                Password = password,
                IsSilent = isSilent,
                QuitAfterActions = true,
            });
        }
        public void Dismount(string driveLetter, bool isSilent = true)
        {
            Execute(new Options
            {
                DismountDriveLetter = driveLetter,
                IsSilent = isSilent,
                QuitAfterActions = true,
            });      
        }

        public void DismountAll()
        {
            Execute(new Options
            {
                DismountAll = true,
                QuitAfterActions = true,
            });
        }

        private void Execute(Options options)
        {
            var process = new Process();
            process.StartInfo.FileName = executablePath;
            process.StartInfo.Arguments = options.ToArgumentsString();
            process.Start();
            process.WaitForExit();
        }
    }
}
