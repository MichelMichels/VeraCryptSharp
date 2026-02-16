using MichelMichels.CliSharp.Core;
using MichelMichels.VeraCryptSharp.Enums;

namespace MichelMichels.VeraCryptSharp;

public static class VeraCryptSwitches
{
    public static CliCommandLineSwitch EnableTrueCryptCompability => new("/truecrypt");
    public static CliCommandLineSwitch OpenFileExplorerAfterMount => new("/explore");
    public static CliCommandLineSwitch BeepOnSuccessfulMount => new("/beep");
    public static CliCommandLineSwitch QuietMode => new("/silent");
    public static CliCommandLineSwitch AutoMount => new("/a");
    public static CliCommandLineSwitch DismountAll => new("/d");
    public static CliCommandLineSwitch ForceDismount => new("/f");
    public static CliCommandLineSwitch QuitAfterActions => new("/q");
    public static CliCommandLineSwitch WipeCache => new("/w");

    public static CliCommandLineSwitch<MountOption> MountOption => new("/m");
    public static CliCommandLineSwitch<HashAlgorithm> HashAlgorithm => new("/hash");

    public static CliCommandLineSwitch<string> Volume => new("/volume");
    public static CliCommandLineSwitch<string> DriveLetter => new("/letter");
    public static CliCommandLineSwitch<string> AutoMountAll => new("/a", "devices");
    public static CliCommandLineSwitch<string> DismountDriveLetter => new("/d");
    public static CliCommandLineSwitch<string> KeyFilePath => new("/k");
    public static CliCommandLineSwitch<string> Password => new("/p");
    public static CliCommandLineSwitch<string> TokenLibraryPath => new("/tokenlib");
    public static CliCommandLineSwitch<string> TokenPin => new("/tokenpin");

    public static CliCommandLineSwitch<int> PersonalIterationsMultiplier => new("/pim");

    public static CliCommandLineSwitch<string> VolumeLabel => new("/m", "label");

    public static CliCommandLineSwitch<Answer> TryEmptyPass => new("/tryemptypass");
    public static CliCommandLineSwitch<Answer> NoWaitDialog => new("/nowaitdlg");
    public static CliCommandLineSwitch<Answer> SecureDesktop => new("/secureDesktop");
    public static CliCommandLineSwitch<Answer> EnablePasswordCache => new("/cache");
    public static CliCommandLineSwitch<Answer> EnableSavingHistory => new("/history");
}
