using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Core
{
    public class CommandLineSwitch
    {
        public CommandLineSwitch()
        {
            Switch = string.Empty;
            Prefix = string.Empty;
            Parameter = string.Empty;
        }

        public string Switch { get; set; }
        public string Prefix { get; set; }
        public string Parameter { get; set; }

        public override string ToString() => $"{Switch} {Prefix}{Parameter}";
    }
}
