using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VeraCryptSharp.Core
{
    public interface IProcessProxy : IDisposable
    {
        void Start();
        void WaitForExit();

        int ExitCode { get; }
        ProcessStartInfo StartInfo { get; set; }
    }
}
