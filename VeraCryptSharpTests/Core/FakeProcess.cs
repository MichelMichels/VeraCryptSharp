using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VeraCryptSharpTests.Core
{
    public class FakeProcess : Process
    {
        public FakeProcess()
        {
            LastCall = string.Empty;
        }

        public string LastCall { get; private set; }

        public new void Start()
        {
            LastCall = $"{StartInfo.FileName} {StartInfo.Arguments}";            
        }
        public new void WaitForExit()
        {
            // No implementation
        }
    }
}
