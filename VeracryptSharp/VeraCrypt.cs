using System;
using System.Diagnostics;
using System.IO;
using CommandLine;
using VeraCryptSharp.Enums;
using VeraCryptSharp.Exceptions;

namespace VeraCryptSharp
{
    public class VeraCrypt : IVeraCrypt
    {
        private readonly string executablePath;
            
        public VeraCrypt(string executablePath)
        {
            if (!File.Exists(executablePath))
                throw new FileNotFoundException("Executable of VeraCrypt not found at given file path", executablePath);

            this.executablePath = executablePath;              
        }

        public void Mount(string filePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "", bool isSilent = false)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("VeraCrypt volume not found at give file path", filePath);

            Execute(new VeraCryptArguments
            {
                Volume = filePath,
                HashAlgorithm = hashAlgorithm,
                DriveLetter = driveLetter,
                Password = password,
                QuietMode = isSilent,
                QuitAfterActions = true,
            });
        }
        public void Dismount(string driveLetter, bool isSilent = false)
        {
            Execute(new VeraCryptArguments
            {
                DismountDriveLetter = driveLetter,
                QuietMode = isSilent,
                QuitAfterActions = true,
            });                  
        }

        public void DismountAll()
        {
            Execute(new VeraCryptArguments
            {
                DismountAll = true,
                QuitAfterActions = true,
            });
        }

        private void Execute(VeraCryptArguments options)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = executablePath,
                    Arguments = options.ToString(),
                    UseShellExecute = false,
                }                
            };

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
                throw new VeraCryptExitException($"Something went wrong.");
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e) => Console.WriteLine(e.Data);
    }
}
