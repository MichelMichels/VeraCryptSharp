using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp.Core;
using VeraCryptSharp.Enums;

namespace VeraCryptSharp
{
    public static class VeraCryptSwitches
    {
        public static CommandLineSwitch EnableTrueCryptCompability => new CommandLineSwitch("/truecrypt");
        public static CommandLineSwitch OpenFileExplorerAfterMount => new CommandLineSwitch("/explore");
        public static CommandLineSwitch BeepOnSuccessfulMount => new CommandLineSwitch("/beep");
        public static CommandLineSwitch QuietMode => new CommandLineSwitch("/silent");
        public static CommandLineSwitch AutoMount => new CommandLineSwitch("/a");
        public static CommandLineSwitch DismountAll => new CommandLineSwitch("/d");
        public static CommandLineSwitch ForceDismount => new CommandLineSwitch("/f");
        public static CommandLineSwitch QuitAfterActions => new CommandLineSwitch("/q");

        public static CommandLineSwitch<MountOption> MountOption => new CommandLineSwitch<MountOption>("/m");
        public static CommandLineSwitch<HashAlgorithm> HashAlgorithm => new CommandLineSwitch<HashAlgorithm>("/hash");

        public static CommandLineSwitch<string> Volume => new CommandLineSwitch<string>("/volume");
        public static CommandLineSwitch<string> DriveLetter => new CommandLineSwitch<string>("/letter");
        public static CommandLineSwitch<string> AutoMountAll => new CommandLineSwitch<string>("/a", "devices");
        public static CommandLineSwitch<string> DismountDriveLetter => new CommandLineSwitch<string>("/d");
        public static CommandLineSwitch<string> KeyFilePath => new CommandLineSwitch<string>("/k");
        public static CommandLineSwitch<string> Password => new CommandLineSwitch<string>("/p");

        public static CommandLineSwitch<int> PersonalIterationsMultiplier => new CommandLineSwitch<int>("/pim");

        public static CommandLineSwitchPrefix<string> VolumeLabel => new CommandLineSwitchPrefix<string>("/m", "label");

        /*        
        /tryemptypass  	ONLY when default keyfile configured or when a keyfile is specified in the command line.
            If it is followed by y or yes or if no parameter is specified: try to mount using an empty password and the keyfile before displaying password prompt.
            if it is followed by n or no: don't try to mount using an empty password and the keyfile, and display password prompt right away.
        /nowaitdlg	If it is followed by y or yes or if no parameter is specified: don’t display the waiting dialog while performing operations like mounting volumes.
            If it is followed by n or no: force the display waiting dialog is displayed while performing operations.
        /secureDesktop	If it is followed by y or yes or if no parameter is specified: display password dialog in a dedicated secure desktop to protect against certain types of attacks.
            If it is followed by n or no: the password dialog is displayed in the normal desktop.
        /tokenlib	It must be followed by a parameter indicating the PKCS #11 library to use for security tokens and smart cards. (e.g.: /tokenlib c:\pkcs11lib.dll)
        /tokenpin	It must be followed by a parameter indicating the PIN to use in order to authenticate to the security token or smart card (e.g.: /tokenpin 0000). Warning: This method of entering a smart card PIN may be insecure, for example, when an unencrypted command prompt history log is being saved to unencrypted disk.
        /cache or /c	If it is followed by y or yes or if no parameter is specified: enable password cache; 
            If it is followed by n or no: disable password cache (e.g., /c n).
            If it is followed by f or favorites: temporary cache password when mounting multiple favorites  (e.g., /c f).
            Note that turning the password cache off will not clear it (use /w to clear the password cache).
        /history or /h	If it is followed by y or no parameter: enables saving history of mounted volumes; if it is followed by n: disables saving history of mounted volumes (e.g., /h n).
        /wipecache or /w	Wipes any passwords cached in the driver memory.
        */
    }
}
