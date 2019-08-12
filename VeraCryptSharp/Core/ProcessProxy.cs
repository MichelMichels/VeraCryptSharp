using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VeraCryptSharp.Core
{
    public class ProcessProxy : IProcessProxy
    {
        private Process _process;

        public ProcessProxy()
        {
            _process = new Process();
        }

        public ProcessStartInfo StartInfo
        {
            get => _process.StartInfo;
            set => _process.StartInfo = value;
        }
        public int ExitCode => _process.ExitCode;

        public void WaitForExit()
        {
            _process.WaitForExit();
        }
        public void Start()
        {
            _process.Start();
        }
        public void Dispose()
        {
            _process.Dispose();
        }
    }
}
