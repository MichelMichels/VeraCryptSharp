using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VeraCryptSharp.Extensions;
using VeraCryptSharp.Enums;

namespace VeraCryptSharp
{
    public class Options
    {
        [ArgumentName("/truecrypt")]
        public bool EnableTrueCryptCompability { get; set; }

        [ArgumentName("/hash")]
        public HashAlgorithm HashAlgorithm { get; set; }

        [ArgumentName("/volume")]
        public string Volume { get; set; }

        [ArgumentName("/letter")]
        public string DriveLetter { get; set; }

        [ArgumentName("/explore")]
        public bool OpenFileExplorerAfterMount { get; set; }

        [ArgumentName("/beep")]
        public bool BeepOnSuccessfulMount { get; set; }

        [ArgumentName("/silent")]
        public bool IsSilent { get; set; }

        [ArgumentName("/a devices")]
        public bool AutoMountAll { get; set; }

        [ArgumentName("/a")]
        public bool AutoMount { get; set; }

        [ArgumentName("/d")]
        public bool DismountAll { get; set; }

        [ArgumentName("/d")]
        public string DismountDriveLetter { get; set; }

        [ArgumentName("/f")]
        public bool ForceDismount { get; set; }

        [ArgumentName("/k")]
        public string KeyFilePath { get; set; }

        [ArgumentName("/q")]
        public bool QuitAfterActions { get; set; }

        [ArgumentName("/p")]
        public string Password { get; set; }
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
        /password or /p	It must be followed by a parameter indicating the volume password. If the password contains spaces, it must be enclosed in quotation marks (e.g., /p ”My Password”). Use /p ”” to specify an empty password. Warning: This method of entering a volume password may be insecure, for example, when an unencrypted command prompt history log is being saved to unencrypted disk.
        /pim	It must be followed by a positive integer indicating the PIM (Personal Iterations Multiplier) to use for the volume.
        /quit or /q	Automatically perform requested actions and exit (main VeraCrypt window will not be displayed). If preferences is specified as the parameter (e.g., /q preferences), then program settings are loaded/saved and they override settings specified on the command line. /q background launches the VeraCrypt Background Task (tray icon) unless it is disabled in the Preferences.
        /silent or /s	If /q is specified, suppresses interaction with the user (prompts, error messages, warnings, etc.). If /q is not specified, this option has no effect.
        /mountoption or /m	
            It must be followed by a parameter which can have one of the values indicated below.

            ro or readonly: Mount volume as read-only.

            rm or removable: Mount volume as removable medium (see section Volume Mounted as Removable Medium).

            ts or timestamp: Do not preserve container modification timestamp.

            sm or system: Without pre-boot authentication, mount a partition that is within the key scope of system encryption (for example, a partition located on the encrypted system drive of another operating system that is not running). Useful e.g. for backup or repair operations. Note: If you supply a password as a parameter of /p, make sure that the password has been typed using the standard US keyboard layout (in contrast, the GUI ensures this automatically). This is required due to the fact that the password needs to be typed in the pre-boot environment (before Windows starts) where non-US Windows keyboard layouts are not available.

            bk or headerbak: Mount volume using embedded backup header. Note: All volumes created by VeraCrypt contain an embedded backup header (located at the end of the volume).

            recovery: Do not verify any checksums stored in the volume header. This option should be used only when the volume header is damaged and the volume cannot be mounted even with the mount option headerbak. Example: /m ro

            label=LabelValue: Use the given string value LabelValue as a label of the mounted volume in Windows Explorer. The maximum length for LabelValue  is 32 characters for NTFS volumes and 11 characters for FAT volumes. For example, /m label=MyDrive will set the label of the drive in Explorer to MyDrive.

            noattach: Only create virtual device without actually attaching the mounted volume to the selected drive letter.

            Please note that this switch may be present several times in the command line in order to specify multiple mount options (e.g.: /m rm /m ts)
        */

        public string ToArgumentsString()
        {
            var arguments = new List<string>();
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                if(property.IsOfType<string>(this))
                {
                    var argumentName = property.GetCustomAttribute<ArgumentName>().Name;
                    var argumentValue = property.GetValue<string>(this);

                    arguments.AddRange(new[] { argumentName, argumentValue });

                } else if(property.IsOfType<bool>(this))
                {
                    var argumentName = property.GetCustomAttribute<ArgumentName>().Name;
                    var argumentValue = property.GetValue<bool>(this);

                    if(argumentValue)
                    {
                        arguments.Add(argumentName);
                    }
                }               
            }

            return String.Join(" ", arguments);
        }
    }     
}
