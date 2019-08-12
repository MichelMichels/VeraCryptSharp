using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Core
{
    public class Command
    {
        public Command(string filePath)
        {
            Program = filePath;
            Switches = new List<CommandLineSwitch>();
        }

        public string Program { get; set; }
        public List<CommandLineSwitch> Switches { get; set; }        
    }
}
