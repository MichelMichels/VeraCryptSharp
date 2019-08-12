using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Core
{
    public interface ICommandLineSwitch
    {
        string Switch { get; set; }
    }

    public interface ICommandLineSwitch<T> : ICommandLineSwitch
    {
        T Value { get; set; }
    }

    public interface ICommandLineSwitchPrefix<T> : ICommandLineSwitch<T>
    {
        string Prefix { get; set; }
    }
}
