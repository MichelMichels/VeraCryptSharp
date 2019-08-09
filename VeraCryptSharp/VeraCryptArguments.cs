using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VeraCryptSharp.Extensions;
using VeraCryptSharp.Enums;
using VeraCryptSharp.Core;
using VeraCryptSharp.Attributes;
using System.Linq;

namespace VeraCryptSharp
{
    public class VeraCryptArguments : Arguments
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
        public bool QuietMode { get; set; }

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

        [ArgumentName("/m")]
        [ArgumentValuePrefix("label=")]
        public string VolumeLabel { get; set; }

        [ArgumentName("/m")]
        public IEnumerable<MountOption> MountOptions { get; set; }

        [ArgumentName("/pim")]
        public int PersonalIterationsMultiplier { get; set; }

        public override IEnumerable<string> GetEnumArgumentsString(IEnumerable<PropertyInfo> properties)
        {
            var hashEnums = GetHashAlgorithmEnumsString(properties.Where(x => x.IsOfType<HashAlgorithm>(this)));
            var otherEnums = base.GetEnumArgumentsString(properties.Where(x => !x.IsOfType<HashAlgorithm>(this)));

            return hashEnums.Concat(otherEnums);
        }

        private IEnumerable<string> GetHashAlgorithmEnumsString(IEnumerable<PropertyInfo> properties)
        {
            return properties
                .OfType<HashAlgorithm>(this)
                .Unpack<HashAlgorithm>(this)
                .Where(x => x.Value != HashAlgorithm.Auto)
                .SelectMany(x => new[] { x.Key, x.Value.ToFriendlyString() });
        }

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
