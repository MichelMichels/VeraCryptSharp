using MichelMichels.CliSharp;
using MichelMichels.CliSharp.Core;
using MichelMichels.CliSharp.Extensions;
using MichelMichels.VeraCryptSharp.Enums;
using System.Collections.Generic;
using System.IO;

namespace MichelMichels.VeraCryptSharp;

public class VeraCrypt : IVeraCrypt
{
    private readonly string executablePath;

    public VeraCrypt(string executablePath)
    {
        if (!File.Exists(executablePath))
        {
            throw new FileNotFoundException("Executable of VeraCrypt not found at given file path", executablePath);
        }

        this.executablePath = executablePath;
    }

    public void Mount(string volumePath, string password, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool isSilent = false)
    {
        Cli
            .SetProgram(executablePath)
            .AddSwitch(VeraCryptSwitches.Volume, volumePath)
            .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
            .AddSwitch(VeraCryptSwitches.Password, password)
            .AddSwitch(VeraCryptSwitches.QuitAfterActions)
            .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
            .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
            .Execute();
    }
    public void MountSecure(string volumePath, HashAlgorithm hashAlgorithm = HashAlgorithm.Auto, string driveLetter = "V", bool useSecureDesktop = false)
    {
        Cli
            .SetProgram(executablePath)
            .AddSwitch(VeraCryptSwitches.Volume, volumePath)
            .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
            .AddSwitch(VeraCryptSwitches.SecureDesktop, useSecureDesktop ? Answer.Yes : Answer.No)
            .AddSwitch(VeraCryptSwitches.QuitAfterActions)
            .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
            .Execute();
    }
    public void Dismount(string driveLetter, bool isSilent = false)
    {
        Cli
            .SetProgram(executablePath)
            .AddSwitch(VeraCryptSwitches.DismountDriveLetter, driveLetter)
            .AddSwitch(VeraCryptSwitches.QuitAfterActions)
            .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
            .Execute();
    }
    public void DismountAll()
    {
        Cli
            .SetProgram(executablePath)
            .AddSwitch(VeraCryptSwitches.DismountAll)
            .AddSwitch(VeraCryptSwitches.QuitAfterActions)
            .Execute();
    }
    public void Execute(IEnumerable<CliCommandLineSwitch> switches)
    {
        var command = Cli.SetProgram(executablePath);

        foreach (var _switch in switches)
        {
            command.AddSwitch(_switch);
        }

        command.Execute();
    }
}
