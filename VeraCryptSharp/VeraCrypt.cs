﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using VeraCryptSharp.Core;
using VeraCryptSharp.Enums;
using VeraCryptSharp.Exceptions;
using VeraCryptSharp.Extensions;

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
            Cli
                .SetProgram(executablePath)
                .AddSwitch(VeraCryptSwitches.Volume, filePath)
                .AddSwitch(VeraCryptSwitches.DriveLetter, driveLetter)
                .AddSwitch(VeraCryptSwitches.Password, password)
                .AddSwitch(VeraCryptSwitches.QuitAfterActions)
                .AddConditionalSwitch(VeraCryptSwitches.HashAlgorithm, hashAlgorithm, hashAlgorithm != HashAlgorithm.Auto)
                .AddConditionalSwitch(VeraCryptSwitches.QuietMode, isSilent)
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
    }
}