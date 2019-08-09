using System;
using System.Collections.Generic;
using System.Text;

namespace VeraCryptSharp.Exceptions
{
    public class VeraCryptExitException : Exception
    {
        public VeraCryptExitException() : base()
        {

        }

        public VeraCryptExitException(string message) : base(message)
        {
            
        }

        public VeraCryptExitException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
