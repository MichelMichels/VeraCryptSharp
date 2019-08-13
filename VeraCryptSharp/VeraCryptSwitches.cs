using CliSharp.Core;
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
        public static CommandLineSwitch WipeCache => new CommandLineSwitch("/w");

        public static CommandLineSwitch<MountOption> MountOption => new CommandLineSwitch<MountOption>("/m");
        public static CommandLineSwitch<HashAlgorithm> HashAlgorithm => new CommandLineSwitch<HashAlgorithm>("/hash");

        public static CommandLineSwitch<string> Volume => new CommandLineSwitch<string>("/volume");
        public static CommandLineSwitch<string> DriveLetter => new CommandLineSwitch<string>("/letter");
        public static CommandLineSwitch<string> AutoMountAll => new CommandLineSwitch<string>("/a", "devices");
        public static CommandLineSwitch<string> DismountDriveLetter => new CommandLineSwitch<string>("/d");
        public static CommandLineSwitch<string> KeyFilePath => new CommandLineSwitch<string>("/k");
        public static CommandLineSwitch<string> Password => new CommandLineSwitch<string>("/p");
        public static CommandLineSwitch<string> TokenLibraryPath => new CommandLineSwitch<string>("/tokenlib");
        public static CommandLineSwitch<string> TokenPin => new CommandLineSwitch<string>("/tokenpin");

        public static CommandLineSwitch<int> PersonalIterationsMultiplier => new CommandLineSwitch<int>("/pim");

        public static CommandLineSwitchPrefix<string> VolumeLabel => new CommandLineSwitchPrefix<string>("/m", "label");

        public static CommandLineSwitch<Answer> TryEmptyPass => new CommandLineSwitch<Answer>("/tryemptypass");
        public static CommandLineSwitch<Answer> NoWaitDialog => new CommandLineSwitch<Answer>("/nowaitdlg");
        public static CommandLineSwitch<Answer> SecureDesktop => new CommandLineSwitch<Answer>("/secureDesktop");
        public static CommandLineSwitch<Answer> EnablePasswordCache => new CommandLineSwitch<Answer>("/cache");
        public static CommandLineSwitch<Answer> EnableSavingHistory => new CommandLineSwitch<Answer>("/history");       
    }
}
